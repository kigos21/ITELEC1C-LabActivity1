using System.ComponentModel.DataAnnotations;

namespace LabActivity1.Models
{
  public enum Rank
  {
    Instructor,
    AssistantProfessor,
    AssociateProfessor,
    Professor
  }

  public class Instructor
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
    [Display(Name = "Tenured")]
    public bool IsTenured { get; set; }

    [Required]
    [Display(Name = "Rank")]
    public Rank Rank { get; set; }

    [Required]
    [Display(Name = "Hiring Date")]
    [DataType(DataType.Date)]
    public DateTime HiringDate { get; set; }
  }
}