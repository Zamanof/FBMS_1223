using Microsoft.EntityFrameworkCore;

public class StudentContext: DbContext
{
    public DbSet<Student> Students { get; set; }

    public StudentContext()
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Students;Integrated Security=True;");
    }
}
