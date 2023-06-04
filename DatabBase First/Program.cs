using DatabBase_First;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

//using (var db = new LibraryContext())
//{
//    var author = db.Authors.First();
//    Console.WriteLine(author);
//}

/*
    LINQ to Entity
    
All
Any
Average
Contains
Count
Find
First
FirstOrDefault
Single
SingleOrDefault
Select
Where
OrderBy
OrderByDecending
ThenBy
ThenByDecending
Join
GroupBy
Union
Except
Sum
Min
Max
Take
Skip
ToList()    
 */

//using (var db = new LibraryContext())
//{
//    //var authors = db.Authors
//    //    .Where(a => a.LastName.EndsWith("ov"))
//    //    .ToList();
//    //authors.ForEach(a => Console.WriteLine(a));

//    // Regular Expression

//    //EF.Functions.Like()

//    //var authors1 = db.Authors
//    //    .Where(a => EF.Functions.Like(a.LastName, "%ov"))
//    //    .ToList();
//    //authors1.ForEach(a => Console.WriteLine(a));
//}


#region Select
//using (var db = new LibraryContext())

//{
//    var authors = db.Authors.Select(a =>
//    new
//    {
//        Id = a.Id,
//        FirstName = a.FirstName,
//        LastName = a.LastName,
//        Books = a.Books
//    })
//        .ToList();

//    foreach (var author in authors)
//    {
//        Console.WriteLine(author.FirstName);
//        foreach (var book in author.Books)
//        {
//            Console.WriteLine($"\t{book.Name}");
//        }
//    }
//}
#endregion


#region Join
/*
SELECT B.[Name], (A.Firstname + ' ' A.LastName) AS AuthorName
FROM Books AS B
INNER JOIN
Authors AS A
ON A.Id = B.IdAuthor
*/

using (var db = new LibraryContext())
{
    var books = db.Books.Join(db.Authors, b => b.IdAuthor, a => a.Id,
        (b, a)=> new
        {
            Name = b.Name,
            AuthorName=$"{a.FirstName} {a.LastName}"  
        })
        .ToList();
    foreach (var book in books)
    {
        Console.WriteLine($"{book.Name} - {book.AuthorName}");
    }
}

#endregion