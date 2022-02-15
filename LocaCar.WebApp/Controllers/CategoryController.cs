using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using LocaCar.WebApp.Services.CategoryServices;
using LocaCar.WebApp.Services.CategoryServices.Dtos.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocaCar.WebApp.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> CreateCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory(Models.CategoryViewModel.Category category)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Fail to post data");
            }

            var jwt = Request.Cookies["Jwt"] ?? string.Empty;
            var response = await _categoryService.CreateCategory(new CreateCategoryRequest(category.Name, category.Description, category.DailyValue), jwt);
            if (response is not null)
            {
                foreach (var item in response.Errors.Where(item => !string.IsNullOrWhiteSpace(item.ErrorMessage)))
                {//thanks ReShaper
                    ModelState.AddModelError(string.Empty, item.ErrorMessage);
                }

                return RedirectToAction("Index", "Home");
            }

            throw new Exception("Failed");
        }
    }
}