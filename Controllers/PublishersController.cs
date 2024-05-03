using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REST_API_TEMPLATEE.Data;
using REST_API_TEMPLATEE.Models.Domain;

namespace REST_API_TEMPLATEE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PublishersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Publishers>> GetPublishers()
        {
            return _context.Publishers.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Publishers> GetPublishers(int id)
        {
            var publishers = _context.Publishers.Find(id);

            if (publishers == null)
            {
                return NotFound();
            }
            return publishers;
        }

        [HttpPost]
        public IActionResult PostPublishers(Publishers publishers)
        {
            _context.Publishers.Add(publishers);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetPublishers), new { id = publishers.Id }, publishers);
        }

        [HttpPut("{id}")]
        public IActionResult PutPublishers(int id, Publishers publishers)
        {
            if (id != publishers.Id)
            {
                return BadRequest();
            }

            _context.Entry(publishers).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePublishers(int id)
        {
            var publishers = _context.Publishers.Find(id);

            if (publishers == null)
            {
                return NotFound();
            }

            _context.Publishers.Remove(publishers);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
