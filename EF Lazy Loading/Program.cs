// See https://aka.ms/new-console-template for more information
using EF_Lazy_Loading;


/* Lazy loading-in istifadəsi üçün tələblər 
 1. Bütün "navigation property" - lər virtual olmalıdır
 və class-lar isə inheritance üçün açıq olmalıdır

 2. context-in konfiqurasiyasında UseLazyLoadingProxies() metodu çağrılmalıdır 
*/

using (var db = new LibraryContext())
{
    var authors = db.Authors.ToList();
    foreach (var author in authors)
    {
        Console.WriteLine(author.LastName);
        foreach(var book in author.Books)
        {
            Console.WriteLine($"\t{book.Name}");
        }
    }
    Console.ReadLine();
    
    Console.Clear();

    foreach (var author in authors)
    {
        Console.WriteLine(author.LastName);
        foreach (var book in author.Books)
        {
            Console.WriteLine($"\t{book.Name}");
        }
    }
}