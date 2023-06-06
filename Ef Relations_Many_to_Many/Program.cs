using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

using (var db = new AppContext())
{
    SocialNetwork OKNetwork = new SocialNetwork() { Name = "OK" };
    SocialNetwork FacebookNetwork = new SocialNetwork() { Name = "Facebook" };
    SocialNetwork InstagramNetwork = new SocialNetwork() { Name = "Instagram" };

    User user = new User()
    {
        FirstName = "Nadir",
        LastName = "Zamanov",
        Login = "mr.13",
        Password = "qwertyuiop123456",
    };
    OKNetwork.Users.Add(user);
    FacebookNetwork.Users.Add(user);
    InstagramNetwork.Users.Add(user);
    db.SocialNetworks.AddRange(OKNetwork, FacebookNetwork, InstagramNetwork);
    db.SaveChanges();
  

}

class User
{
    public int Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }

    public List<SocialNetwork> SocialNetworks { get; set; }= new List<SocialNetwork>();

}

class SocialNetwork
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<User> Users { get; set; }= new List<User>();
}

class AppContext : DbContext
{
    
    public DbSet<SocialNetwork> SocialNetworks { get; set;} 
    public DbSet<User> Users { get; set;} 
    public AppContext()
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=UsersManyToMany;Integrated Security=True;");
    }
}
