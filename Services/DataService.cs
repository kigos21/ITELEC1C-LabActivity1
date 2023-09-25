using System;
using LabActivity1.Services;
using LabActivity1.Models;

namespace LabActivity1.Services
{
  public class DataService : DataServiceInterface
  {
    public List<Student> StudentList { get; }
    public List<Instructor> InstructorList { get; }

    public DataService()
    {
      StudentList = new List<Student>()
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
        }
      };

      InstructorList = new List<Instructor>()
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
    }
  }
}