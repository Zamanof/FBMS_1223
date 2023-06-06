using Microsoft.EntityFrameworkCore;
using (var database = new AppContext())
{
    //var student = new Student()
    //{
    //    FirstName = "Alexander",
    //    LastName = "of Macedon",
    //    BirthDate = new DateTime(356, 7, 20),
    //};

    //var studentCard = new StudentCard()
    //{
    //    StartDate = new DateTime(366, 7, 20),
    //    EndDate = new DateTime(370, 7, 20),
    //    Student = student
    //};
    //database.StudentCards.Add(studentCard);
    //database.SaveChanges();

    var st = database.StudentCards.Include(s => s.Student).ToList();
    Console.WriteLine(st[0].Student);
    Console.WriteLine(st[0]);
}
