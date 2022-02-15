using LocaCar.WebApp.Models.UsersViewModel;
using LocaCar.WebApp.Services.AccountServices;
using LocaCar.WebApp.Services.AccountServices.Dtos.Request;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LocaCar.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountSvc;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(IAccountService accountSvc, SignInManager<IdentityUser> signInManager)
        {
            _accountSvc = accountSvc;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return RedirectToAction("Index", "Home");
        }

        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegister register)
        {
            if (!ModelState.IsValid) throw new Exception("Teste");
            
            var userPostModel = new UserRegisterPostDto(register.Email, register.UserName, register.Password,
                register.Phone);
            var response = await _accountSvc.UserRegisterService(userPostModel);
            if (response.Email is "") throw new Exception("Falha no cadastro");

            var identityUser = new IdentityUser()
            {
                Id = response.Id,
                Email = response.Email,
                UserName = response.Name,
            };
            await _signInManager.SignInAsync(identityUser, isPersistent: false);
            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLogin login)
        {
            if (!ModelState.IsValid) throw new Exception("Testing");

            var userLoginModel = new UserLoginPostDto(login.Email, login.Password);
            var response = await _accountSvc.UserLoginService(userLoginModel);
            
            if (response.Email is "") throw new Exception("Failed login");

            SetJwt(response.JwtToken, response.ValidDate);
            var identityUser = new IdentityUser()
            {
                Id = response.Id,
                Email = response.Email,
                UserName = response.Name,
            };
            await _signInManager.SignInAsync(identityUser, false);
            return RedirectToAction("Index", "Home");

        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private void SetJwt(string value, DateTime expireDate)
        {
            var option = new CookieOptions
            {
                Expires = expireDate
            };

            Response.Cookies.Append("jwt", value, option);
        }

        private string? GetJwt()
        {
            return Request.Cookies["Jwt"];
        }
    }
}