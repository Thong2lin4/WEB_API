using Microsoft.EntityFrameworkCore;
using REST_API_TEMPLATEE.Controllers;
using REST_API_TEMPLATEE.Models;
using REST_API_TEMPLATEE.Models.Domain;
using REST_API_TEMPLATEE.Models.DTO;
using static System.Reflection.Metadata.BlobBuilder;

namespace REST_API_TEMPLATEE.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { // có thể dinh nghia moi quan he giua cac table bang Fluent API
            modelBuilder.Entity<Book_Author>()
            .HasOne(b => b.Book).WithMany(ba => ba.Book_Author)
            .HasForeignKey(bi => bi.BookId);
            modelBuilder.Entity<Book_Author>().HasOne(b => b.Author).
        WithMany(ba => ba.Book_Authors).HasForeignKey(bi => bi.AuthorId);
            modelBuilder.Entity<addBookRequestDTO>()
                  .HasNoKey();
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book_Author> Books_Authors { get; set; }
        public DbSet<Publishers> Publishers { get; set; }
        public DbSet<BookWithAuthorAndPublisherDTO> bookWithAuthorAndPublisherDTOs { get; set; }
        public DbSet<addBookRequestDTO> AddBookRequestDTOs { get; set; }

    }
}
