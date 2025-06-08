using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoleBasedProductAPI.Data;
using RoleBasedProductAPI.Models;

namespace RoleBasedProductAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TransactionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var transactions = _context.Transactions
                .Include(t => t.Product)
                .ToList();
            return Ok(transactions);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var transaction = _context.Transactions
                .Include(t => t.Product)
                .FirstOrDefault(t => t.Id == id);
            if (transaction == null) return NotFound();
            return Ok(transaction);
        }
    }
}
