using Microsoft.AspNetCore.Mvc;
using LabActivity1.Models;

public class InstructorController : Controller
{
  List<Instructor> InstructorList = new List<Instructor>()
    {
      new Instructor()
      {
        Id = 1,
        FirstName = "Minette",
        LastName = "Chavez",
        IsTenured = false,
        Rank = Rank.Professor,
        HiringDate = DateTime.Parse("08/20/2023")
      },
      new Instructor()
      {
        Id = 2,
        FirstName = "Noel",
        LastName = "Cansino",
        IsTenured = true,
        Rank = Rank.Professor,
        HiringDate = DateTime.Parse("08/25/2023")
      },
      new Instructor()
      {
        Id = 3,
        FirstName = "Kevin",
        LastName = "Coraza",
        IsTenured = true,
        Rank = Rank.Professor,
        HiringDate = DateTime.Parse("09/01/2023")
      },
    };
  public IActionResult Index()
  {
    return View(InstructorList);
  }

  public IActionResult Details(int id)
  {
    Instructor? instructor = InstructorList.FirstOrDefault(instructor => instructor.Id == id);

    if (instructor == null)
    {
      return NotFound();
    }

    return View(instructor);
  }

  [HttpGet]
  public IActionResult AddInstructor()
  {
    return View();
  }

  [HttpPost]
  public IActionResult AddInstructor(Instructor newInstructor)
  {
    InstructorList.Add(newInstructor);
    return View("Index", InstructorList);
  }

  [HttpGet]
  public IActionResult Edit(int id)
  {
    Instructor? instructor = InstructorList.FirstOrDefault(instructor => instructor.Id == id);

    if (instructor == null)
    {
      return NotFound();
    }

    return View(instructor);
  }

  [HttpPost]
  public IActionResult Edit(Instructor updatedInstructor)
  {
    Instructor? instructor = InstructorList.FirstOrDefault(instructor => instructor.Id == updatedInstructor.Id);

    if (instructor == null)
    {
      return NotFound();
    }

    instructor.FirstName = updatedInstructor.FirstName;
    instructor.LastName = updatedInstructor.LastName;
    instructor.IsTenured = updatedInstructor.IsTenured;
    instructor.Rank = updatedInstructor.Rank;
    instructor.HiringDate = updatedInstructor.HiringDate;

    return View("Index", InstructorList);
  }

  [HttpGet]
  public IActionResult Delete(int id)
  {
    Instructor? instructor = InstructorList.FirstOrDefault(instructor => instructor.Id == id);
    InstructorList.Remove(instructor);
    return View("Index", InstructorList);
  }
}