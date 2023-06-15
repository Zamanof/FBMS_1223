using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Dapper_ORM;

internal class AuthorRepository : IAuthorRepository
{
    private IDbConnection _db;

    public AuthorRepository()
    {
        _db = new SqlConnection();
        _db.ConnectionString =
            @"Server=(localdb)\MSSQLLocalDB;
            Database=Library;
            Integrated Security=True;
            TrustServerCertificate=True;";
    }

    public Author AddAuthor(Author author)
    {
        var sql =
            @"INSERT INTO Authors (FirstName, LastName)
              VALUES (@FirstName, @LastName)
              SELECT CAST(SCOPE_IDENTITY() AS int)";
        var id = _db.Query<int>(sql, new
        {
            @FirstName = author.FirstName,
            @LastName = author.LastName
        }).FirstOrDefault();
        author.Id = id;
        return author;
    }

    public void AddAuthors(object[] authors)
    {
        var sql = @"INSERT INTO Authors (FirstName, LastName)
              VALUES (@FirstName, @LastName)";
        _db.Execute(sql, authors);
    }

    public Author GetAuthorById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Author> GetAuthors()
    {
        var sql = "SELECT * FROM Authors";
        return _db.Query<Author>(sql);
    }

    public void RemoveAuthor(int id)
    {
        _db.Execute("DELETE FROM Authors WHERE Id=@Id", new { @Id = id });
    }

    public void RemoveAuthorsByIds(int[] authorIds)
    {
        foreach (var authorId in authorIds)
            RemoveAuthor(authorId);
    }

    public void RemoveAuthorsByRange(int start, int end)
    {
        for (int i = start; i <= end; i++)
        {
            RemoveAuthor(i);
        }
    }

    public Author UpdateAuthor(Author author)
    {
        throw new NotImplementedException();
    }

    public void UpdateAuthors(object[] authors)
    {
        throw new NotImplementedException();
    }
}
