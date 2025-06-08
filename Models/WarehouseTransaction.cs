using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoleBasedProductAPI.Models
{
    public class WarehouseTransaction
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public string? DeliverySlipNumber { get; set; }
        public string? ReceiptNumber { get; set; }
        public string? ShippingSlipNumber { get; set; }
        public string TransactionType { get; set; } = "IN"; // IN or OUT
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
