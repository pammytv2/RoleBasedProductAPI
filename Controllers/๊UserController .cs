using Microsoft.AspNetCore.Mvc;
using RoleBasedProductAPI.Data;
using RoleBasedProductAPI.Models;

namespace RoleBasedProductAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/users/register
        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // ตรวจสอบ Email ซ้ำ
            var exists = _context.Users.Any(u => u.Email == user.Email);
            if (exists)
                return BadRequest("Email already registered.");

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(new { message = "Registration successful", user });
        }

        //  GET: api/users
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_context.Users.ToList());
        }

        //  GET: api/users/5
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // PUT: api/users/5
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User updated)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();

            user.Username = updated.Username;
            user.Email = updated.Email;
            user.Password = updated.Password;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();

            _context.Users.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
