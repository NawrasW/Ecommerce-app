namespace Ecommerce.Server.Models.Domain
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public Product Product { get; set; } // Reference to the Product class
        public int Quantity { get; set; }

        
        public int OrderId { get; set; }
        public Order Order { get; set; }

    }
}
