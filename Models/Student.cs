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
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
    public string Email { get; set; }
    public Major Major { get; set; }
  }

}
