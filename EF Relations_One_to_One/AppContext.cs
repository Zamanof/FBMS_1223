using Microsoft.EntityFrameworkCore;

class AppContext: DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<StudentCard> StudentCards { get; set; }

    public AppContext()
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=StudentsOneToOne;Integrated Security=True;");
    }
}