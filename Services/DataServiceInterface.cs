using System;
using LabActivity1.Services;
using LabActivity1.Models;

namespace LabActivity1.Services
{
  public interface DataServiceInterface
  {
    List<Student> StudentList { get; }
    List<Instructor> InstructorList { get; }
  }
}