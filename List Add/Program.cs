using System.Collections.Concurrent;

int parallelCount = 0;

List<Student> students = new();
//BlockingCollection<Student> blockingCollection = new BlockingCollection<Student>();

for (int i = 0; i < 10; i++)
{
    students.Add(new Student());
}

foreach (var student in students)
{
    Console.WriteLine(student);
}
class Student
{
    static int _count = 0;
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int Age { get; set; }
    public string? Email { get; set; }
    public string? GroupName { get; set; }

    public Student()
    {
        Random random = new Random();

        Id = _count++;
        int gender = random.Next(1, 3);
        if ( gender % 2 == 0) 
            FirstName = Faker.NameFaker.FirstName();
        else 
            FirstName = Faker.NameFaker.FemaleFirstName();

        LastName = Faker.NameFaker.LastName();
        Age = Faker.NumberFaker.Number(18, 100);
        Email = Faker.InternetFaker.Email();
        GroupName = $"FBMS_{Faker.NumberFaker.Number(1000, 2000)}";
    }

    public override string ToString()
    {
        return $@"Id: {Id}
Name: {FirstName}
Surname: {LastName}
Age: {Age}
Email: {Email}
Group: {GroupName}
{new string('_', 35)}";
    }
}
