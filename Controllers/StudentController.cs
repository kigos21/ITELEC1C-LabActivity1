using Microsoft.AspNetCore.Mvc;
using LabActivity1.Services;
using LabActivity1.Models;
using LabActivity1.Data;

namespace LabActivity1.Controllers;

public class StudentController : Controller
{
  private readonly AppDbContext _dbContext;

  public StudentController(AppDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public IActionResult Index()
  {
    return View(_dbContext.Students);
  }

  [HttpGet]
  public IActionResult AddStudent()
  {
    return View();
  }

  [HttpPost]
  public IActionResult AddStudent(Student newStudent)
  {
    _dbContext.Students.Add(newStudent);
    _dbContext.SaveChanges();
    return RedirectToAction("Index");
  }

  public IActionResult Details(int id)
  {
    Student? student = _dbContext.Students.FirstOrDefault(student => student.Id == id);

    if (student == null)
    {
      return NotFound();
    }

    return View(student);
  }

  [HttpGet]
  public IActionResult Edit(int id)
  {
    Student? student = _dbContext.Students.FirstOrDefault(student => student.Id == id);

    if (student == null)
    {
      return NotFound();
    }

    return View(student);
  }

  [HttpPost]
  public IActionResult Edit(Student updatedStudent)
  {
    Student? student = _dbContext.Students.FirstOrDefault(student => student.Id == updatedStudent.Id);

    if (student == null)
    {
      return NotFound();
    }

    student.FirstName = updatedStudent.FirstName;
    student.LastName = updatedStudent.LastName;
    student.Birthdate = updatedStudent.Birthdate;
    student.Email = updatedStudent.Email;
    student.Major = updatedStudent.Major;
    _dbContext.SaveChanges();

    return RedirectToAction("Index");
  }

  [HttpGet]
  public IActionResult Delete(int id)
  {
    Student? student = _dbContext.Students.FirstOrDefault(student => student.Id == id);

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
      return RedirectToAction("Index");
    }

    Student? student = _dbContext.Students.FirstOrDefault(student => student.Id == id);

    if (student == null)
    {
      return NotFound();
    }

    _dbContext.Students.Remove(student);
    _dbContext.SaveChanges();

    return RedirectToAction("Index");
  }
}
