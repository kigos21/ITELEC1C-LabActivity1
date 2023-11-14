using System.ComponentModel.DataAnnotations;

namespace LabActivity1.Models
{
  public enum Major
  {
    BSCS,
    BSIT,
    BSIS,
    OTHER
  }

  public class Student
  {
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "First name is required.")]
    [Display(Name = "First name")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required.")]
    [Display(Name = "Last name")]
    public string? LastName { get; set; }

    [Required]
    [Display(Name = "Birthdate")]
    [DataType(DataType.Date)]
    public DateTime Birthdate { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    public Major Major { get; set; }
  }
}
