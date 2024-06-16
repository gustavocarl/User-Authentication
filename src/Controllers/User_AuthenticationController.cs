using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using User_Authentication.Data;
using User_Authentication.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace User_Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class User_AuthenticationController : ControllerBase
    {
        private readonly User_AuthenticationContext? _context;

        public User_AuthenticationController(User_AuthenticationContext context)
        {
            _context = context;
        }

        // GET: api/<User_Authentication>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await _context!.Users.ToListAsync();
        }

        // GET api/<User_Authentication>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = _context!.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST api/<User_Authentication>
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User user)
        {
            _context!.Users.Add(user);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        // PUT api/<User_Authentication>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context!.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/<User_Authentication>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context!.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}