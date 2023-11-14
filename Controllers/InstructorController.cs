using Microsoft.AspNetCore.Mvc;
using LabActivity1.Models;
using LabActivity1.Services;
using LabActivity1.Data;

public class InstructorController : Controller
{
  private readonly AppDbContext _dbContext;

  public InstructorController(AppDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public IActionResult Index()
  {
    return View(_dbContext.Instructors);
  }

  [HttpGet]
  public IActionResult AddInstructor()
  {
    return View();
  }

  [HttpPost]
  public IActionResult AddInstructor(Instructor newInstructor)
  {
    if (!ModelState.IsValid)
    {
      return View();
    }

    _dbContext.Instructors.Add(newInstructor);
    _dbContext.SaveChanges();
    return RedirectToAction("Index");
  }

  public IActionResult Details(int id)
  {
    Instructor? instructor = _dbContext.Instructors.FirstOrDefault(instructor => instructor.Id == id);

    if (instructor == null)
    {
      return NotFound();
    }

    return View(instructor);
  }

  [HttpGet]
  public IActionResult Edit(int id)
  {
    Instructor? instructor = _dbContext.Instructors.FirstOrDefault(instructor => instructor.Id == id);

    if (instructor == null)
    {
      return NotFound();
    }

    return View(instructor);
  }

  [HttpPost]
  public IActionResult Edit(Instructor updatedInstructor)
  {
    if (!ModelState.IsValid)
    {
      return View();
    }

    Instructor? instructor = _dbContext.Instructors.FirstOrDefault(instructor => instructor.Id == updatedInstructor.Id);

    if (instructor == null)
    {
      return NotFound();
    }

    instructor.FirstName = updatedInstructor.FirstName;
    instructor.LastName = updatedInstructor.LastName;
    instructor.IsTenured = updatedInstructor.IsTenured;
    instructor.Rank = updatedInstructor.Rank;
    instructor.HiringDate = updatedInstructor.HiringDate;
    _dbContext.SaveChanges();

    return RedirectToAction("Index");
  }

  [HttpGet]
  public IActionResult Delete(int id)
  {
    Instructor? instructor = _dbContext.Instructors.FirstOrDefault(instructor => instructor.Id == id);

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

    Instructor? instructor = _dbContext.Instructors.FirstOrDefault(instructor => instructor.Id == id);

    if (instructor == null)
    {
      return NotFound();
    }

    _dbContext.Instructors.Remove(instructor);
    _dbContext.SaveChanges();
    return RedirectToAction("Index");
  }
}