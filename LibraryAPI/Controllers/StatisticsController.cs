using LibraryAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly LibraryContext _context;

        public StatisticsController(LibraryContext context)
        {
            _context = context;
        }

        // GET /api/statistics
        [HttpGet]
        public IActionResult GetStatistics()
        {
            var statistics = new
            {
                TotalBooks = _context.Books.Count(),
                TotalBorrows = _context.BorrowedBooks.Count(),
                CategoryCounts = _context.Books.GroupBy(b => b.Category)
                    .Select(g => new { Category = g.Key, Count = g.Count() }).ToList()
            };

            return Ok(statistics);
        }
    }
}
