public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string Lastname { get; set; }

    public DateTime BirthDate { get; set; }

    public override string? ToString()
    {
        return $@"_________ {Id} _________
First Name: {FirstName}
Last Name:  {Lastname}
Birth Date  {BirthDate.ToShortDateString()}
";
    }
}
