namespace Dapper_ORM;

public class Author
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public override string ToString()
    {
        return @$"Id: {Id}
Firstname: {FirstName}
Lastname:{LastName}
";
    }
}