using Microsoft.AspNetCore.Mvc;
using LabActivity1.Services;
using LabActivity1.Models;

namespace LabActivity1.Controllers;

public class StudentController : Controller
{
  private readonly DataServiceInterface data;

  public StudentController(DataServiceInterface _data)
  {
    data = _data;
  }

  public IActionResult Index()
  {
    return View(data.StudentList);
  }

  [HttpGet]
  public IActionResult AddStudent()
  {
    return View();
  }

  [HttpPost]
  public IActionResult AddStudent(Student newStudent)
  {
    data.StudentList.Add(newStudent);
    return RedirectToAction("Index");
  }

  public IActionResult Details(int id)
  {
    Student? student = data.StudentList.FirstOrDefault(student => student.Id == id);

    if (student == null)
    {
      return NotFound();
    }

    return View(student);
  }

  [HttpGet]
  public IActionResult Edit(int id)
  {
    Student? student = data.StudentList.FirstOrDefault(student => student.Id == id);

    if (student == null)
    {
      return NotFound();
    }

    return View(student);
  }

  [HttpPost]
  public IActionResult Edit(Student updatedStudent)
  {
    Student? student = data.StudentList.FirstOrDefault(student => student.Id == updatedStudent.Id);

    if (student == null)
    {
      return NotFound();
    }

    student.FirstName = updatedStudent.FirstName;
    student.LastName = updatedStudent.LastName;
    student.Birthdate = updatedStudent.Birthdate;
    student.Email = updatedStudent.Email;
    student.Major = updatedStudent.Major;

    return RedirectToAction("Index");
  }

  [HttpGet]
  public IActionResult Delete(int id)
  {
    Student? student = data.StudentList.FirstOrDefault(student => student.Id == id);

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

    Student? student = data.StudentList.FirstOrDefault(student => student.Id == id);

    if (student == null)
    {
      return NotFound();
    }

    data.StudentList.Remove(student);
    return RedirectToAction("Index");
  }
}