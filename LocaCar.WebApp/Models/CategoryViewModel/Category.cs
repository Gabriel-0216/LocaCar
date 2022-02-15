using System.ComponentModel.DataAnnotations;

namespace LocaCar.WebApp.Models.CategoryViewModel;

public class Category
{
    [Required(ErrorMessage = "The field is required")]
    [DataType(DataType.Text, ErrorMessage = "This field must be a text")]
    public string Name { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "The field is required")]
    [DataType(DataType.Text, ErrorMessage = "This field must be a text")]
    public string Description { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "The field is required")]
    [DataType(DataType.Currency, ErrorMessage = "This field must be a currency")]
    public decimal DailyValue { get; set; }
}