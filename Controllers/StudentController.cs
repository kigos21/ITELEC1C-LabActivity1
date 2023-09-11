using Microsoft.AspNetCore.Mvc;
using LabActivity1.Models;

namespace LabActivity1.Controllers;

public class StudentController : Controller
{
  public IActionResult Index()
  {
    List<Student> StudentList = new List<Student>()
    {
        new Student()
        {
          Id = 1,
          FirstName = "John",
          LastName = "De Castro",
          Birthdate = DateOnly.Parse("07/21/2003"),
          Email = "jd@gmail.com",
          Major = Major.BSIT
        },
        new Student()
        {
          Id = 2,
          FirstName = "Melfred",
          LastName = "Fonclara",
          Birthdate = DateOnly.Parse("01/14/2002"),
          Email = "melfred@gmail.com",
          Major = Major.BSCS
        },
        new Student()
        {
          Id = 3,
          FirstName = "Karl",
          LastName = "Tacula",
          Birthdate = DateOnly.Parse("12/29/2002"),
          Email = "karl@gmail.com",
          Major = Major.BSIS
        },
    };

    return View(StudentList);
  }
}