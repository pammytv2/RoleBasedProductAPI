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

            var exists = _context.Users.Any(u => u.Email == user.Email);
            if (exists)
                return BadRequest("Email already registered.");

            // ตั้งค่า default เป็น "user" ถ้าไม่ได้ส่งมา
            if (string.IsNullOrEmpty(user.Role))
                user.Role = "user";

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
            user.Role = updated.Role;

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
        // POST: api/users/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest credentials)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = _context.Users
                .FirstOrDefault(u => u.Email == credentials.Email && u.Password == credentials.Password);

            if (user == null)
                return Unauthorized("Invalid email or password.");

            return Ok(new { message = "Login successful", user });
        }

    }
}
