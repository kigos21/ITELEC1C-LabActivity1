using System;
using System.ComponentModel.DataAnnotations;

namespace LabActivity1.ViewModels
{
  public class LoginViewModel
  {
    [Display(Name = "Username")]
    [Required(ErrorMessage = "A username is required!")]
    public string? UserName { get; set; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "A password is required!")]
    public string? Password { get; set; }

    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; }
  }
}