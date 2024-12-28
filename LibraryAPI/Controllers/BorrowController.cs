using LibraryAPI.Data;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowController : ControllerBase
    {
        private readonly LibraryContext _context;

        public BorrowController(LibraryContext context)
        {
            _context = context;
        }

        // GET /api/borrow
        [HttpGet]
        public IActionResult GetAllBorrowedBooks()
        {
            var borrows = _context.BorrowedBooks.Select(bb => new
            {
                bb.BorrowId,
                bb.BookId,
                bb.UserId,
                BookTitle = bb.Book.Title,
                Author = bb.Book.Author,
                bb.BorrowDate
            }).ToList();

            return Ok(borrows);
        }

        // GET /api/borrow/{id}
        [HttpGet("{id}")]
        public IActionResult GetBorrowById(int id)
        {
            var borrow = _context.BorrowedBooks
                .Where(bb => bb.BorrowId == id)
                .Select(bb => new
                {
                    bb.BorrowId,
                    bb.BookId,
                    bb.UserId,
                    BookTitle = bb.Book.Title,
                    Author = bb.Book.Author,
                    bb.BorrowDate
                }).FirstOrDefault();

            if (borrow == null)
            {
                return NotFound();
            }

            return Ok(borrow);
        }

        // POST /api/borrow
        [HttpPost]
        public IActionResult AddBorrow([FromBody] BorrowedBook newBorrow)
        {
            _context.BorrowedBooks.Add(newBorrow);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetBorrowById), new { id = newBorrow.BorrowId }, newBorrow);
        }

        // PUT /api/borrow/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateBorrow(int id, [FromBody] BorrowedBook updatedBorrow)
        {
            var borrow = _context.BorrowedBooks.Find(id);
            if (borrow == null)
            {
                return NotFound();
            }

            borrow.BorrowDate = updatedBorrow.BorrowDate;
            borrow.ReturnDate = updatedBorrow.ReturnDate;

            _context.SaveChanges();
            return NoContent();
        }

        // GET /api/borrow/history
        [HttpGet("history")]
        public IActionResult GetBorrowHistory()
        {
            var history = _context.BorrowedBooks.Select(bb => new
            {
                bb.BorrowId,
                bb.BookId,
                bb.UserId,
                BookTitle = bb.Book.Title,
                Author = bb.Book.Author,
                bb.BorrowDate,
                bb.ReturnDate
            }).ToList();

            return Ok(history);
        }
    }
}
