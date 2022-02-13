namespace LocaCar.WebApp.Services.AccountServices.Dtos.Request
{
    public class UserRegisterPostDto
    {
        public UserRegisterPostDto(string email, string name, string password, string cellphone)
        {
            Email = email;
            Name = name;
            Password = password;
            Cellphone = cellphone;
        }
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Cellphone { get; set; } = string.Empty;
    }
}
