// ORM - Object Relational Mapping

#region Add Data
//using (StudentContext database = new())
//{
//Student student = new()
//{
//    FirstName = "Anjelina",
//    Lastname = "Jolie",
//    BirthDate = new DateTime(1975, 6, 4)
//};
//database.Students.Add(student);
//database.Students.Add(student);

//Student student1 = new()
//{
//    FirstName = "Salam",
//    Lastname = "Salamzade",
//    BirthDate = new DateTime(2023, 1, 1)
//};

//Student student2 = new()
//{
//    FirstName = "Brad",
//    Lastname = "Pitt",
//    BirthDate = new DateTime(1963, 12, 18)
//};

//Student student3 = new()
//{
//    FirstName = "Nadir",
//    Lastname = "Zamanov",
//    BirthDate = new DateTime(1980, 10, 7)
//};

//database.Students.Add(student1);
//database.Students.Add(student2);
//database.Students.Add(student3);
//database.SaveChanges();

//}
#endregion

#region Read Data
//using (var database = new StudentContext())
//{
//    //var student = database.Students.FirstOrDefault();
//    //if (student is not null)
//    //{
//    //    Console.WriteLine(student);
//    //}
//    //var student2 = database.Students
//    //    .FirstOrDefault(x=>x.FirstName == "Nadir");
//    //Console.WriteLine(student2);
//}
#endregion

#region Add Datas
//using(var db = new StudentContext())
//{
//    List<Student> students = new()
//    {
//        new Student{
//            FirstName = "Abdulsalam",
//            Lastname = "Abdullayev",
//            BirthDate = new DateTime(1998, 1, 24),
//        },
//        new Student{
//            FirstName = "Turgut",
//            Lastname = "Aliyev",
//            BirthDate = new DateTime(2001, 7, 17),
//        },
//        new Student{
//            FirstName = "Shamsi",
//            Lastname = "Alizade",
//            BirthDate = new DateTime(2004, 9, 22),
//        },
//        new Student{
//            FirstName = "Feyruz",
//            Lastname = "Alekberli",
//            BirthDate = new DateTime(2004, 6, 6),
//        },
//        new Student{
//            FirstName = "Aqshin",
//            Lastname = "Humbatov",
//            BirthDate = new DateTime(2007, 10, 24),
//        },
//        new Student{
//            FirstName = "Orxan",
//            Lastname = "Huseynov",
//            BirthDate = new DateTime(2006, 7, 5),
//        }
//    };
//    db.AddRange(students);
//    db.SaveChanges();
//}
#endregion

#region Read Datas
//using (StudentContext db = new StudentContext())
//{
//    //IQueryable<Student> students = db.Students.Where(s=>s.BirthDate.Year > 1980);

//    //foreach (var student in students.ToList())
//    //{
//    //    Console.WriteLine(student);
//    //}

//    var students1 = db.Students.Where(s => s.FirstName.StartsWith("A")).ToList();
//    students1.ForEach(s => Console.WriteLine(s));

//}
#endregion

#region DeleteData
//using (var db = new StudentContext())
//{
//var student = db.Students.FirstOrDefault(s => s.FirstName == "Salam");
//db.Remove(student);
//db.SaveChanges();
//showStudents(db.Students.ToList());
//}
#endregion

#region Update Data
//Student student = null;

//using(var db = new StudentContext())
//{
//    student = db.Students.FirstOrDefault(s => s.Id == 4);
//    if (student is not null)
//    {
//        student.Lastname = "Zaman";
//        db.Students.Update(student);
//        db.SaveChanges();
//    }
//    showStudents(db.Students.ToList());
//}




#endregion

#region MyRegion
//using (var db = new StudentContext())
//{
//    var students = db.Students.Where(s => s.BirthDate.Year <= 1980);
//    db.RemoveRange(students);
//    db.SaveChanges();
//    showStudents(db.Students.ToList());
//}
#endregion

void showStudents(List<Student> students)
{
    students.ForEach(s => Console.WriteLine(s));
}
