using LabActivity1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LabActivity1.Data
{
  public class AppDbContext : IdentityDbContext<User>
  {
    public DbSet<Student> Students { get; set; }
    public DbSet<Instructor> Instructors { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Student>().HasData(
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
      );

      modelBuilder.Entity<Instructor>().HasData(
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
        }
      );
    }
  }
}