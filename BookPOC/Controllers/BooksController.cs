using BookAPI.Models;
using BookAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBooksService _booksSevice;
        public BooksController(IBooksService booksSevice, ILogger<BooksController> logger)
        {
            _logger = logger;
            _booksSevice = booksSevice;
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(Book bookData)
        {
            try
            {
                var result = await _booksSevice.AddBook(bookData);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception raised during AddBook with message: {ex.Message}");
                return BadRequest(ex.Message);
            }
            
        }
        
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            try
            {
                var result = await _booksSevice.GetBooks();
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception raised during GetBooks with message: {ex.Message}");
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetBookById([FromRoute] Guid id)
        {
            try
            {
                var result = await _booksSevice.GetBookById(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception raised during GetBookbyId with message: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
