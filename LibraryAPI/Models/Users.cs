namespace LibraryAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public ICollection<BorrowedBook> BorrowedBooks { get; set; } = new List<BorrowedBook>();
    }
}
