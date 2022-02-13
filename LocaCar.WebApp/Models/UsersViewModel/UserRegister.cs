using System.ComponentModel.DataAnnotations;

namespace LocaCar.WebApp.Models.UsersViewModel;

public class UserRegister
{
    [Required]
    [Display(Name = "User Name")]
    [DataType(DataType.Text)]
    public string UserName { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Email")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = string.Empty;
    [Required]
    [Display(Name = "Senha")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [DataType(DataType.Password)]
    [Display(Name = "Confirme a senha")]
    [Compare("Password", ErrorMessage = "As senhas não conferem")]
    public string ConfirmPassword { get; set; } = string.Empty;
    [Required]
    [Display(Name = "Número de telefone")]
    [DataType(DataType.PhoneNumber)]
    public string Phone { get; set; } = string.Empty;
}