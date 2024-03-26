using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Server.Models.Domain
{
    public class Order
    {
        //public int OrderId { get; set; }
        [Key]
        public string? SessionId { get; set; }

        public string? PubKey { get; set; }

        public DateTime OrderDate { get; set; }
        //public List<OrderItem> Items { get; set; }

        // Additional properties and methods can be added based on your requirements
    }
}
