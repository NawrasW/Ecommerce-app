using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Server.Models.Domain
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

       
        public string Name { get; set; }

        public string Icon { get; set; }
    }
}
