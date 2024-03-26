using Ecommerce.Server.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace YourProjectNamespace
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-V3IHLGA\\SQLEXPRESS;Initial Catalog=Ecommerce;Integrated Security=true;MultipleActiveResultSets=True;TrustServerCertificate=True");

            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}