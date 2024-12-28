using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BorrowedBook> BorrowedBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API konfigurace
            modelBuilder.Entity<BorrowedBook>()
                .HasOne(bb => bb.Book)
                .WithMany()
                .HasForeignKey(bb => bb.BookId);

            modelBuilder.Entity<BorrowedBook>()
                .HasOne(bb => bb.User)
                .WithMany(u => u.BorrowedBooks)
                .HasForeignKey(bb => bb.UserId);

            modelBuilder.Entity<BorrowedBook>()
                .HasKey(bb => bb.BorrowId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
