namespace RoleBasedProductAPI.Models
{
    public class WithdrawRequest
    {
        public int Quantity { get; set; }
        public string? DeliverySlipNumber { get; set; }
        public string? ReceiptNumber { get; set; }
        public string? ShippingSlipNumber { get; set; }
    }
}