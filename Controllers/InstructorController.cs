using Microsoft.AspNetCore.Mvc;
using LabActivity1.Models;
using LabActivity1.Services;

public class InstructorController : Controller
{
  private readonly DataServiceInterface data;

  public InstructorController(DataServiceInterface _data)
  {
    data = _data;
  }

  public IActionResult Index()
  {
    return View(data.InstructorList);
  }

  [HttpGet]
  public IActionResult AddInstructor()
  {
    return View();
  }

  [HttpPost]
  public IActionResult AddInstructor(Instructor newInstructor)
  {
    data.InstructorList.Add(newInstructor);
    return RedirectToAction("Index");
  }

  public IActionResult Details(int id)
  {
    Instructor? instructor = data.InstructorList.FirstOrDefault(instructor => instructor.Id == id);

    if (instructor == null)
    {
      return NotFound();
    }

    return View(instructor);
  }

  [HttpGet]
  public IActionResult Edit(int id)
  {
    Instructor? instructor = data.InstructorList.FirstOrDefault(instructor => instructor.Id == id);

    if (instructor == null)
    {
      return NotFound();
    }

    return View(instructor);
  }

  [HttpPost]
  public IActionResult Edit(Instructor updatedInstructor)
  {
    Instructor? instructor = data.InstructorList.FirstOrDefault(instructor => instructor.Id == updatedInstructor.Id);

    if (instructor == null)
    {
      return NotFound();
    }

    instructor.FirstName = updatedInstructor.FirstName;
    instructor.LastName = updatedInstructor.LastName;
    instructor.IsTenured = updatedInstructor.IsTenured;
    instructor.Rank = updatedInstructor.Rank;
    instructor.HiringDate = updatedInstructor.HiringDate;

    return RedirectToAction("Index");
  }

  [HttpGet]
  public IActionResult Delete(int id)
  {
    Instructor? instructor = data.InstructorList.FirstOrDefault(instructor => instructor.Id == id);

    if (instructor == null)
    {
      return NotFound();
    }

    return View(instructor);
  }

  [HttpPost]
  public IActionResult DeletePost(int id)
  {
    // if user clicked cancel
    if (id == -1)
    {
      return RedirectToAction("Index");
    }

    Instructor? instructor = data.InstructorList.FirstOrDefault(instructor => instructor.Id == id);

    if (instructor == null)
    {
      return NotFound();
    }

    data.InstructorList.Remove(instructor);
    return RedirectToAction("Index");
  }
}