using Microsoft.AspNetCore.Mvc;
using LabActivity1.Models;

namespace LabActivity1.Controllers;

public class StudentController : Controller
{
  List<Student> StudentList = new List<Student>()
    {
        new Student()
        {
          Id = 1,
          FirstName = "John",
          LastName = "De Castro",
          Birthdate = DateTime.Parse("07/21/2003"),
          Email = "jd@gmail.com",
          Major = Major.BSIT
        },
        new Student()
        {
          Id = 2,
          FirstName = "Melfred",
          LastName = "Fonclara",
          Birthdate = DateTime.Parse("01/14/2002"),
          Email = "melfred@gmail.com",
          Major = Major.BSCS
        },
        new Student()
        {
          Id = 3,
          FirstName = "Karl",
          LastName = "Tacula",
          Birthdate = DateTime.Parse("12/29/2002"),
          Email = "karl@gmail.com",
          Major = Major.BSIS
        },
    };

  public IActionResult Index()
  {
    return View(StudentList);
  }

  [HttpGet]
  public IActionResult AddStudent()
  {
    return View();
  }

  [HttpPost]
  public IActionResult AddStudent(Student newStudent)
  {
    StudentList.Add(newStudent);
    return View("Index", StudentList);
  }

  public IActionResult Details(int id)
  {
    Student? student = StudentList.FirstOrDefault(student => student.Id == id);

    if (student == null)
    {
      return NotFound();
    }

    return View(student);
  }

  [HttpGet]
  public IActionResult Edit(int id)
  {
    Student? student = StudentList.FirstOrDefault(student => student.Id == id);

    if (student == null)
    {
      return NotFound();
    }

    return View(student);
  }

  [HttpPost]
  public IActionResult Edit(Student updatedStudent)
  {
    Student? student = StudentList.FirstOrDefault(student => student.Id == updatedStudent.Id);

    if (student == null)
    {
      return NotFound();
    }

    student.FirstName = updatedStudent.FirstName;
    student.LastName = updatedStudent.LastName;
    student.Birthdate = updatedStudent.Birthdate;
    student.Email = updatedStudent.Email;
    student.Major = updatedStudent.Major;

    return View("Index", StudentList);
  }

  [HttpGet]
  public IActionResult Delete(int id)
  {
    Student? student = StudentList.FirstOrDefault(student => student.Id == id);

    if (student == null)
    {
      return NotFound();
    }

    return View(student);
  }

  [HttpPost]
  public IActionResult DeletePost(int id)
  {
    // user cancel operation
    if (id == -1)
    {
      return View("Index", StudentList);
    }

    Student? student = StudentList.FirstOrDefault(student => student.Id == id);

    if (student == null)
    {
      return NotFound();
    }

    StudentList.Remove(student);
    return View("Index", StudentList);
  }
}