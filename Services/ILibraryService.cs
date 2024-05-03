using REST_API_TEMPLATEE.Models;
using REST_API_TEMPLATEE.Models.Domain;
using static System.Reflection.Metadata.BlobBuilder;
namespace REST_API_TEMPLATEE.Services
{
    public interface ILibraryService
        {
        // Authors
        Task<List<Author>> GetAuthorsAsync();
        Task<Author> GetAuthorAsync(int id);
        Task<Author> AddAuthorAsync(Author author);
        Task<Author> UpdateAuthorAsync(Author author);
        Task<(bool, string)> DeleteAuthorAsync(Author author);

        // Publishers
        Task<List<Publishers>> GetPublishersAsync();
        Task<Publishers> GetPublisherAsync(int id);
        Task<Publishers> AddPublisherAsync(Publishers publisher);
        Task<Publishers> UpdatePublisherAsync(Publishers publisher);
        Task<(bool, string)> DeletePublisherAsync(Publishers publisher);

        // Books
        Task<List<Book>> GetBooksAsync();
        Task<Book> GetBookAsync(int id);
        Task<Book> AddBookAsync(Book book);
        Task<Book> UpdateBookAsync(Book book);
        Task<(bool, string)> DeleteBookAsync(Book book);
    }
}
