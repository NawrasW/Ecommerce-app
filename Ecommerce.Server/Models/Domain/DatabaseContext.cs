using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
//using static System.Collections.Specialized.BitVector32;

namespace Ecommerce.Server.Models.Domain
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }



    }
}
