using EF_Core_Loadings;
using Microsoft.EntityFrameworkCore;


// Eager loading - acgöz yüklənmə
// Explicit loading - aşkar yüklənmə
// Lazy laoading - tənbəl yüklənmə


#region Eager loading

//using (var db = new LibraryContext())
//{
//    // include
//    //var authors = db.Authors.Include(b => b.Books).ToList();
//    //foreach (var author in authors)
//    //{
//    //    Console.WriteLine(author);
//    //    foreach (var book in author.Books)
//    //        Console.WriteLine(book);
//    //}

//    var faculties = db.Faculties
//        .Include(f => f.Groups)
//        .ThenInclude(g => g.Students)
//        .ToList();

//    foreach (var faculty in faculties)
//    {
//        Console.WriteLine(faculty.Name);
//        foreach(var group in faculty.Groups)
//        {
//            Console.WriteLine($"\t{group.Name}");
//            foreach(var student in group.Students)
//                Console.WriteLine($"\t\t{student.FirstName} {student.LastName}");
//        }
//    }



//}

#endregion

#region Explicit loading

using (LibraryContext db = new())
{
    var author = db.Authors.FirstOrDefault(a => a.LastName == "Arkhangelsky");
    //var books = db.Books.Where(b => b.IdAuthor == author!.Id).ToList();
    //foreach (var book in books)
    //{
    //    Console.WriteLine(book);
    //}
    //db.Books.Where(b => b.IdAuthor == author!.Id).Load();

    //Console.WriteLine(author);
    //foreach (var book in author!.Books)
    //{
    //    Console.WriteLine(book);
    //}

    //db.Books.Where(b => b.IdAuthor < 5).Load();
    //Console.WriteLine(db.Authors.FirstOrDefault(a=>a.Id == 4).Books.ToList()[0]);
    //Console.WriteLine(db.Authors.FirstOrDefault(a=>a.Id == 4).Books.ToList()[1]);

}

#endregion
