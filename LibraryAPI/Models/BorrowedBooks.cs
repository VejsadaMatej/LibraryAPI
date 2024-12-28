namespace LibraryAPI.Models
{
    public class BorrowedBook
    {
        public int BorrowId { get; set; } // Primární klíč
        public int BookId { get; set; } // Cizí klíč na Book
        public int UserId { get; set; } // Cizí klíč na User
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public Book Book { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
