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
                new Product { Name = "Product A", Price = 100m, Stock = 50 },
                new Product { Name = "Product B", Price = 200m, Stock = 30 },
                new Product { Name = "Product C", Price = 300m, Stock = 20 }
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