using REST_API_TEMPLATEE.Models;
using REST_API_TEMPLATEE.Models.Domain;
using REST_API_TEMPLATEE.Models.DTO;

namespace REST_API_TEMPLATEE.Repositories
{
    public interface IBookRepository
    {
        List<BookWithAuthorAndPublisherDTO> GetAllBooks();
        BookWithAuthorAndPublisherDTO GetBookById(int id);
        addBookRequestDTO AddBook(addBookRequestDTO addBookRequestDTO);
        addBookRequestDTO? UpdatebookById(int id, addBookRequestDTO bookDTO);
        Book? DeleteBookById(int id);
        object UpdateBookById(int id, addBookRequestDTO bookDTO);
    }
}
