namespace Dapper_ORM;

internal interface IAuthorRepository
{
    Author AddAuthor(Author author);
    void AddAuthors(object[] authors);
    void RemoveAuthor(int id);
    void RemoveAuthorsByRange(int start, int end);
    void RemoveAuthorsByIds(int[] authorIds);
    Author UpdateAuthor(Author author);
    void UpdateAuthors(object[] authors);
    Author GetAuthorById(int id);
    IEnumerable<Author> GetAuthors();
}
