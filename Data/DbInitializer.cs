using System.Linq;
using RoleBasedProductAPI.Models;

namespace RoleBasedProductAPI.Data
{
    public static class DbInitializer
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (context.Products.Any())
            {
                return; // DB has been seeded
            }

            var products = new Product[]
            {
                new Product { Name = "ค้อน", Price = 120m, Stock = 10 },
                new Product { Name = "ไขควง", Price = 80m, Stock = 15 },
                new Product { Name = "ประแจ", Price = 150m, Stock = 20 }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
