using System.ComponentModel.DataAnnotations;

namespace LocaCar.WebApp.Models.UsersViewModel;

public class UserLogin
{
    [Required]
    [Display(Name = "Email")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = string.Empty;
    [Required]
    [Display(Name = "Password")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
}