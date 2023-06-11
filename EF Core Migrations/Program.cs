using Microsoft.EntityFrameworkCore;

using (var db = new StudentContext())
{
    //var student = new Student()
    //{
    //    FirstName = "Vusal",
    //    LastName = "Huseynov"
    //};
    //db.Students.Add(student);
    //db.SaveChanges();

    //db.Students.Add(new Student()
    //{
    //    FirstName = "Nadir",
    //    LastName = "Zamanov",
    //    Age= 42
    //});

    db.Students.Add(new Student()
    {
        FirstName = "Ridan",
        LastName = "Namazov",
        Age = 24,
        GroupName = "FBMS_1223_az",
        BirthDate = DateTime.Now
    });

    db.SaveChanges();
    var students = db.Students.ToList();
    students.ForEach(s => Console.WriteLine(s));
}


public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int? Age { get; set; }
    public string GroupName { get; set; }
    public DateTime BirthDate { get; set; }
    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }

}

public class StudentContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    public StudentContext()
    {
        //Database.EnsureDeleted();
        //Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=EFMigration;Integrated Security=True;");
    }
}