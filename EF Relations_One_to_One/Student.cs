class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public virtual StudentCard Card { get; set; }

    public override string? ToString()
    {
        return $"{FirstName} {LastName} {BirthDate.ToShortDateString()}";
    }
}
