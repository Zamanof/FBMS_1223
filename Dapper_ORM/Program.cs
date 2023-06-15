using Dapper_ORM;

AuthorRepository authorRepository = new AuthorRepository();
//var author = authorRepository.AddAuthor(new Author
//{
//    FirstName = "Ilyas",
//    LastName = "Efendiyev"
//});
//Console.WriteLine(author);

//var authors = authorRepository.GetAuthors().ToList();

//authors.ForEach(author => Console.WriteLine(author));

//authorRepository.AddAuthors(new[]
//{
//    new Author{FirstName = "Mirze Elekber", LastName="Tahirzade"},
//    new Author{FirstName = "Semed", LastName="Vekilov"},
//    new Author{FirstName = "Isa", LastName="Huseynov"},
//    new Author{FirstName = "Nikolay", LastName="Qoqol"},
//    new Author{FirstName = "Abbas", LastName="Mehdizade"},
//    new Author{FirstName = "Celil", LastName="Memmedquluzade"},
//    new Author{FirstName = "Yusif Vezir", LastName="Chemenzeminli"}
//} );

//var authors = authorRepository.GetAuthors().ToList();

//authors.ForEach(author => Console.WriteLine(author));
//for (int i = 0; i < 10000; i++)
//{
//    authorRepository.AddAuthors(new[]
//    {
//        new Author{FirstName = $"{i}Mirze Elekber", LastName="Tahirzade"},
//        new Author{FirstName = $"{i}Semed", LastName="Vekilov"},
//        new Author{FirstName = $"{i}Isa", LastName="Huseynov"},
//        new Author{FirstName = $"{i}Nikolay", LastName="Qoqol"},
//        new Author{FirstName = $"{i}Abbas", LastName="Mehdizade"},
//        new Author{FirstName = $"{i}Celil", LastName="Memmedquluzade"},
//        new Author{FirstName = $"{i}Yusif Vezir", LastName="Chemenzeminli"}
//    });
//}

//authorRepository.RemoveAuthor(15);
//authorRepository.RemoveAuthorsByIds(new int[] { 17, 58, 18, 69 });

authorRepository.RemoveAuthorsByRange(110000, 400000);

