
// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

using (var db = new AppContext())
{
    //var students = new List<Student>()
    //{
    //    new Student()
    //    {
    //        FirstName = "Alexander",
    //        LastName = "of Macedon",
    //        BirthDate = new DateTime(356, 7, 20)
    //    },
    //    new Student()
    //    {
    //        FirstName = "Julius",
    //        LastName = "Caesar",
    //        BirthDate = new DateTime(100, 7, 12)
    //    },
    //    new Student()
    //    {
    //        FirstName = "Brutus",
    //        LastName = "Ibn Julius",
    //        BirthDate = new DateTime(125, 10, 23)
    //    },
    //    new Student()
    //    {
    //        FirstName = "Mark Tuliy",
    //        LastName = "Siseron",
    //        BirthDate = new DateTime(94, 1, 3)
    //    }

    //};

    //Group ancientRome = new Group()
    //{
    //    GroupName = "AncientRome_1223_lt",
    //    Students = students

    //};

    //var ninjas = new List<Student>()
    //{
    //    new Student()
    //    {
    //        FirstName = "Leonardo",
    //        LastName = "Ibn Splinter",
    //        BirthDate = new DateTime(1982, 7, 20)
    //    },
    //    new Student()
    //    {
    //        FirstName = "Mickelangelo",
    //        LastName = "Ibn Splinter",
    //        BirthDate = new DateTime(1982, 7, 12)
    //    },
    //    new Student()
    //    {
    //        FirstName = "Donatello",
    //        LastName = "Ibn Splinter",
    //        BirthDate = new DateTime(1982, 10, 23)
    //    },
    //    new Student()
    //    {
    //        FirstName = "Rafael",
    //        LastName = "Ibn Splinter",
    //        BirthDate = new DateTime(1982, 1, 3)
    //    }

    //};

    //Group TMNT = new Group()
    //{
    //    GroupName = "TMNT_1223_en",
    //    Students = ninjas

    //};
    //db.Groups.AddRange(ancientRome, TMNT);
    //db.SaveChanges();

    var st = new Student()
    {
        FirstName = "Nadir",
        LastName = "Zamanov",
        BirthDate = new DateTime(1980, 10, 7),
        Group = new Group() { GroupName = "FBMS_1223_az" }
    };

    db.Students.Add(st);
    db.SaveChanges();
}



class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }

    public int GroupId { get; set; }
    public virtual Group Group { get; set; }

    public override string? ToString()
    {
        return $"{FirstName} {LastName} {BirthDate.ToShortDateString()}";
    }
}

class Group
{
    public int Id { get; set; }
    public string GroupName { get; set; }
    public List<Student> Students { get; set; } = new();
}

class AppContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Group> Groups { get; set; }
   public AppContext()
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=StudentsOneToMany;Integrated Security=True;");
    }
}
