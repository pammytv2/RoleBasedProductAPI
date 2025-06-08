using Microsoft.AspNetCore.Mvc;
using RoleBasedProductAPI.Data;
using RoleBasedProductAPI.Models;

namespace RoleBasedProductAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Products.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        // POST: api/products/{id}/withdraw
        [HttpPost("{id}/withdraw")]
        public IActionResult Withdraw(int id, [FromBody] WithdrawRequest request)
        {
            if (request.Quantity <= 0)
                return BadRequest("Quantity must be greater than zero.");

            var product = _context.Products.Find(id);
            if (product == null)
                return NotFound();

            if (product.Stock < request.Quantity)
                return BadRequest("Insufficient stock.");

            product.Stock -= request.Quantity;

            var transaction = new WarehouseTransaction
            {
                ProductId = id,
                Quantity = request.Quantity,
                DeliverySlipNumber = request.DeliverySlipNumber,
                ReceiptNumber = request.ReceiptNumber,
                ShippingSlipNumber = request.ShippingSlipNumber,
                TransactionType = "OUT"
            };
            _context.Transactions.Add(transaction);
            _context.SaveChanges();

            return Ok(new { product, transaction });
        }

        [HttpPost("{id}/deposit")]
        public IActionResult Deposit(int id, [FromBody] WithdrawRequest request)
        {
            if (request.Quantity <= 0)
                return BadRequest("Quantity must be greater than zero.");

            var product = _context.Products.Find(id);
            if (product == null)
                return NotFound();

            product.Stock += request.Quantity;

            var transaction = new WarehouseTransaction
            {
                ProductId = id,
                Quantity = request.Quantity,
                DeliverySlipNumber = request.DeliverySlipNumber,
                ReceiptNumber = request.ReceiptNumber,
                ShippingSlipNumber = request.ShippingSlipNumber,
                TransactionType = "IN"
            };
            _context.Transactions.Add(transaction);
            _context.SaveChanges();

            return Ok(new { product, transaction });
        }
    }
}