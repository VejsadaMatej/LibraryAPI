namespace LibraryAPI.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty; // ENUM lze reprezentovat stringem nebo intem
        public string Description { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty; // Přidáno jako string pro enum (přečteno/nepřečteno)
        public DateTime CreatedAt { get; set; }
    }
}
