using System.ComponentModel.DataAnnotations;

namespace LabActivity1.ViewModels
{
  public class RegisterViewModel
  {
    [Display(Name = "Username")]
    [Required(ErrorMessage = "A username is required!")]
    public string? UserName { get; set; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "A password is required!")]
    public string? Password { get; set; }

    [Display(Name = "Confirm password")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Retype your password.")]
    public string? ConfirmPassword { get; set; }

    [Display(Name = "First name")]
    public string? FirstName { get; set; }

    [Display(Name = "Last name")]
    public string? LastName { get; set; }

    [Display(Name = "Email address")]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Email address is required!")]
    public string? Email { get; set; }

    [RegularExpression("[0-9]{3}-[0-9]{3}-[0-9]{4}", ErrorMessage = "You must follow the format 000-000-0000")]
    [Display(Name = "Phone number")]
    public string? Phone { get; set; }
  }
}