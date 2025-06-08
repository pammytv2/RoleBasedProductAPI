using RoleBasedProductAPI.Models;

namespace RoleBasedProductAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Ensure database exists
            context.Database.EnsureCreated();

            // If data already seeded, return
            if (context.Products.Any() || context.Users.Any() || context.Transactions.Any())
                return;

            var users = new List<User>
            {
                new User { Username = "admin", Email = "admin@example.com", Password = "admin", Role = "admin" },
                new User { Username = "user", Email = "user@example.com", Password = "user", Role = "user" }
            };
            context.Users.AddRange(users);

            var products = new List<Product>
            {
                new Product { Name = "ค้อน", Price = 120m, Stock = 10 },
                new Product { Name = "ไขควง", Price = 80m, Stock = 15 },
                new Product { Name = "ประแจ", Price = 150m, Stock = 20 }
            };
            context.Products.AddRange(products);
            context.SaveChanges();

            var transactions = new List<WarehouseTransaction>
            {
                new WarehouseTransaction
                {
                    ProductId = products[0].Id,
                    Quantity = 10,
                    DeliverySlipNumber = "DS001",
                    TransactionType = "IN"
                },
                new WarehouseTransaction
                {
                    ProductId = products[1].Id,
                    Quantity = 5,
                    ShippingSlipNumber = "SS001",
                    TransactionType = "OUT"
                }
            };
            context.Transactions.AddRange(transactions);
            context.SaveChanges();
        }
    }
}