using Microsoft.EntityFrameworkCore;
using REST_API_TEMPLATEE.Data;
using REST_API_TEMPLATEE.Models;
using REST_API_TEMPLATEE.Models.Domain;
using static System.Reflection.Metadata.BlobBuilder;

namespace REST_API_TEMPLATEE.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly AppDbContext _db;

        public LibraryService(AppDbContext db)
        {
            _db = db;
        }

        // Students Services

        public async Task<List<Author>> GetAuthorsAsync()
        {
            try
            {
                return await _db.Authors.ToListAsync();
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
                return null;
            }
        }

        public async Task<Author> GetAuthorAsync(int id)
        {
            try
            {
                return await _db.Authors.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
                return null;
            }
        }

        public async Task<Author> AddAuthorAsync(Author author)
        {
            try
            {
                await _db.Authors.AddAsync(author);
                await _db.SaveChangesAsync();
                return await _db.Authors.FindAsync(author.Id);
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
                return null;
            }
        }

        public async Task<Author> UpdateAuthorAsync(Author author)
        {
            try
            {
                _db.Entry(author).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return author;
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
                return null;
            }
        }

        public async Task<(bool, string)> DeleteAuthorAsync(Author author)
        {
            try
            {
                var Author = await _db.Authors.FindAsync(author.Id);
                if (Author == null)
                {
                    return (false, "Student not found.");
                }

                _db.Authors.Remove(Author);
                await _db.SaveChangesAsync();
                return (true, "Student deleted successfully.");
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
                return (false, $"An error occurred: {ex.Message}");
            }
        }

        // Courses Services

        public async Task<List<Book>> GetBooksAsync()
        {
            try
            {
                return await _db.Book.ToListAsync();
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
                return null;
            }
        }

        public async Task<Book> GetBookAsync(int id)
        {
            try
            {
                return await _db.Book.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
                return null;
            }
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            try
            {
                await _db.Book.AddAsync(book);
                await _db.SaveChangesAsync();
                return book;
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
                return null;
            }
        }

        public async Task<Book> UpdateBookAsync(Book book)
        {
            try
            {
                _db.Entry(book).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return book;
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
                return null;
            }
        }

        public async Task<(bool, string)> DeleteBookAsync(Book book)
        {
            try
            {
                var Book = await _db.Book.FindAsync(book.Id);
                if (Book == null)
                {
                    return (false, "Course not found.");
                }

                _db.Book.Remove(Book);
                await _db.SaveChangesAsync();
                return (true, "Course deleted successfully.");
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
                return (false, $"An error occurred: {ex.Message}");
            }
        }

        // StudentCourses Services

        public async Task<List<Publishers>> GetPublishersAsync()
        {
            try
            {
                return await _db.Publishers.ToListAsync();
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
                return null;
            }
        }

        public async Task<Publishers> GetPublisherAsync(int id)
        {
            try
            {
                return await _db.Publishers.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
                return null;
            }
        }

        public async Task<Publishers> AddPublisherAsync(Publishers publishers)
        {
            try
            {
                await _db.Publishers.AddAsync(publishers);
                await _db.SaveChangesAsync();
                return publishers;
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
                return null;
            }
        }

        public async Task<Publishers> UpdatePublisherAsync(Publishers publishers)
        {
            try
            {
                _db.Entry(publishers).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return publishers;
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
                return null;
            }
        }

        public async Task<(bool, string)> DeletePublisherAsync(Publishers publishers)
        {
            try
            {
                var publishers1 = await _db.Publishers.FindAsync(publishers.Id);
                if (publishers1 == null)
                {
                    return (false, "Course not found.");
                }

                _db.Publishers.Remove(publishers1);
                await _db.SaveChangesAsync();
                return (true, "Course deleted successfully.");
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
                return (false, $"An error occurred: {ex.Message}");
            }
        }
    }
}