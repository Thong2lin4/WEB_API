using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REST_API_TEMPLATEE.Data;
using REST_API_TEMPLATEE.Models.Domain;
using REST_API_TEMPLATEE.Services;

namespace REST_API_TEMPLATEE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<AuthorController> _logger;
        public AuthorController(AppDbContext context, ILogger<AuthorController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Author>> GetAuthor()
        {
            return _context.Authors.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Author> GetAuthor(int id)
        {
            var author = _context.Authors.Find(id);

            if (author == null)
            {
                return NotFound();
            }

            return author;
        }

        [HttpPost]
        public async Task<ActionResult<Author>> AddAuthorAsync(Author author)
        {
            await _context.SaveChangesAsync();
            try
            {
                var dbauthors = await _context.Authors.AddAsync(author);
                _logger.LogInformation($"{author.FullName} added successfully.");

                return CreatedAtAction("Getauthors", new { id = author.Id }, author);

            }

            catch (Exception ex)
            {

                _logger.LogError($"An error occurred while adding student: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding author.");
            }

        }

        [HttpPut("{id}")]
        public IActionResult PutAuthor(int id, Author author)
        {
            if (id != author.Id)
            {
                return BadRequest();
            }

            _context.Entry(author).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            var author = _context.Authors.Find(id);

            if (author == null)
            {
                return NotFound();
            }

            _context.Authors.Remove(author);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
