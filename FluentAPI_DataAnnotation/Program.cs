// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

// convention
// Data Annotation
// Fluent API

using (var db = new ProductContext())
{
    var country = new Country() { Name = "Azerbaijan" };
    var manufacturer = new Manufacturer() { Name = "Milla", Country = country };
    var product = new Product() { Name = "Ayran", Manufacturer = manufacturer, Price = 1 };
    db.Products.Add(product);
    db.SaveChanges();

}

 //[Index(nameof(Name), IsUnique =true)]
public class Product
{
    //[Key]
    public int ProductNumber { get; set; }
    [Required]
    [MaxLength(20)]
    public string? Name { get; set; }
    [Column("Product_Price")]
    public float Price { get; set; }
    [NotMapped]
    public string Description { get; set; }
    public int ManufacturerId { get; set; }

    public Manufacturer? Manufacturer { get; set; }

}

//[NotMapped]
public class Country
{
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }
}

public class Manufacturer
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public Product Product { get; set; }
    
    public int CountryId { get; set; }
    public Country? Country { get; set; }
}

public class ProductContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public ProductContext()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=FluentApiProducts;Integrated Security=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Manufacturer>().Property(m => m.Name).IsRequired();
        modelBuilder.Ignore<Country>();
        modelBuilder.Entity<Product>(
            entity =>
            {
                entity.HasKey(p => p.ProductNumber);
                //entity.HasIndex(p => p.Name).IsUnique();
                //entity.Property("Price").HasColumnName("Product_price");
            }
     );
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Manufacturer)
            .WithOne(m => m.Product);
    }
}

