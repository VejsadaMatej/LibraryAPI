using LibraryAPI.Data;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly LibraryContext _context;

        public BooksController(LibraryContext context)
        {
            _context = context;
        }

        // GET /api/books
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _context.Books.Select(b => new
            {
                b.BookId,
                b.Title,
                b.Author,
                b.Category
            }).ToList();

            return Ok(books);
        }

        // GET /api/books/{id}
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // POST /api/books
        [HttpPost]
        public IActionResult AddBook([FromBody] Book newBook)
        {
            _context.Books.Add(newBook);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetBookById), new { id = newBook.BookId }, newBook);
        }

        // PUT /api/books/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Category = updatedBook.Category;
            book.Description = updatedBook.Description;
            book.ISBN = updatedBook.ISBN;
            book.Location = updatedBook.Location;
            book.Status = updatedBook.Status;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE /api/books/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
