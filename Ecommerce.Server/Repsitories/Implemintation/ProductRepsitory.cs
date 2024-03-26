using Ecommerce.Server.Models.Domain;
using Ecommerce.Server.Repsitories.Abstrarct;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Server.Repsitories.Implemintation
{
    
    public class ProductRepsitory : IProductRepsitory
    {
        private readonly DatabaseContext _db;

        public ProductRepsitory(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<bool> AddUpdate(Product product)
        {
            try
            {
                // Set Quantity to 1 if it's not explicitly provided
                if (product.Quantity == 0)
                {
                    product.Quantity = 1;
                }

                if (product.ProductId == 0)
                {
                    await _db.Products.AddAsync(product);
                }
                else
                {
                    _db.Products.Update(product);
                }

                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var record = await _db.Products.FirstOrDefaultAsync(product => product.ProductId == id);

                if (record == null)
                    return false;

                _db.Products.Remove(record);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Product>> GetAll()
        {
            try
            {
                return await _db.Products.ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Product> GetById(int id)
        {
            return await _db.Products.FirstOrDefaultAsync(product => product.ProductId == id) ?? new Product();
        }

        public async Task<List<Product>> GetProductsByCategoryId(int categoryId)
        {
            return await _db.Products.Where(Product => Product.CategoryId == categoryId).ToListAsync() ?? new List<Product>();
        }
    }
}

