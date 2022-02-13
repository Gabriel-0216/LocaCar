namespace LocaCar.WebApp.Services.AccountServices.Dtos.Response
{
    public class UserRegisterResponseDto
    {
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string JwtToken { get; set; } = string.Empty;
        public DateTime ValidDate { get; set; }
    }
}
