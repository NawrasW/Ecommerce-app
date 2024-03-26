using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace Ecommerce.Server.Models.Domain
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImageData { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public int Quantity { get; set; } = 1;

        [ForeignKey("Category")]

        public int? CategoryId { get; set; }
        [JsonIgnore] // This property will be excluded from serialization
        public virtual Category? Category { get; set; } 
    }
}
