using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var options = GetOptions("DefaultConnection");

using (var db = new LibraryContext(options))
{
    var author = db.Authors.First();
    Console.WriteLine(author);
}

DbContextOptions<LibraryContext> GetOptions(string configName)
{
    var builder = new ConfigurationBuilder();
    builder.SetBasePath(Directory.GetCurrentDirectory());
    builder.AddJsonFile("AppConfig.json");
    var config = builder.Build();
    string connecionString = config.GetConnectionString(configName)!;
    DbContextOptionsBuilder<LibraryContext> optionsBuilder
        = new DbContextOptionsBuilder<LibraryContext>();
    optionsBuilder.UseSqlServer(connecionString);
    var options = optionsBuilder.Options;
    return options;
} 

class Author
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }


    public override string ToString()
    {
        return $"{Id} {FirstName} {LastName}";
    }
}

class LibraryContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public LibraryContext(DbContextOptions<LibraryContext> options):base(options)
    {
    }
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    //var builder = new ConfigurationBuilder();
    //    //builder.SetBasePath(Directory.GetCurrentDirectory());
    //    //builder.AddJsonFile("AppConfig.json");
    //    //var config = builder.Build();
    //    //string connecionString = config.GetConnectionString("DefaultConnection")!;
    //    //optionsBuilder.UseSqlServer(connecionString);
    //}
}