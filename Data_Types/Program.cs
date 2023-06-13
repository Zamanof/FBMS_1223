
using Microsoft.EntityFrameworkCore;
using(var db = new TestContext())
{
    var test = new Test();
    db.Tests.Add(test);
    db.SaveChanges();
}

#region SQL <--> C# Data types
/*
MS SQL          C#

int             int (Int32)
bit             bool (Boolean)
smallint        short (Int16)
tinyint         byte (Int8)
bigint          long (Int64)


date            DateTime
datetime        DateTime
datetime2       DateTime

float           double (Double)
real            float (Single)

decimal         decimal
money           decimal

char            string
nchar           string
varchar         string
nvarchar        string
text            string
ntext           string

 
 */
#endregion

class Test
{
    public int Id { get; set; }
    public decimal field2 { get; set; }
    public bool field3 { get; set; }
    public short field4 { get; set; }
    public short field5 { get; set; }
    public long field1 { get; set; }
    public float field6 { get; set; }
    public double field7 { get; set; }

}

class TestContext : DbContext
{
    public DbSet<Test> Tests { get; set; }

    public TestContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=TestDatatype;Integrated Security=True;");
    }
}
