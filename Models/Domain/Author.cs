using System.ComponentModel.DataAnnotations;

namespace REST_API_TEMPLATEE.Models.Domain
{
    public class Author
    {
        internal object Books;
        internal object Book;

        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<Book_Author> Book_Authors { get; set; }

    }
}
