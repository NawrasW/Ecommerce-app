using Ecommerce.Server.Models.Domain;
using Ecommerce.Server.Repsitories.Abstrarct;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ecommerce.Server.Repsitories.Implemintation
{
    public class CategoryRepsitory : ICategoryRepsitory
    {


        private readonly DatabaseContext _db;


        public CategoryRepsitory(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<bool> AddUpdateCategory(Category category)
        {
            try
            {
                if (category.CategoryId == 0)
                {

                    await _db.Categories.AddAsync(category);
                }
                else
                {

                    _db.Categories.Update(category);
                }
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteCategory(int Id)
        {
            try
            {
                var record = await _db.Categories.FirstOrDefaultAsync(cate => cate.CategoryId == Id);

                if (record == null)
                    return false;
                _db.Categories.Remove(record);
                await _db.SaveChangesAsync();
                return true;
            }

            catch (Exception ex)
            {

                return false;

            }
        }

        public async Task<List<Category>> GetAllCategory()
        {
            List<Category> result = await _db.Categories.Select(cate => new Category
            {
                CategoryId = cate.CategoryId,
                Name = cate.Name,
                Icon= cate.Icon,
               
            }).ToListAsync();
            return result;
        }

        public async Task<List<Category>> GetAllCategoryLookup()
        {
            List<Category> result = await _db.Categories.Select(cate => new Category
            {
                CategoryId = cate.CategoryId,
                Name = cate.Name,
            }).ToListAsync();
            return result;
        }

        public async Task<List<Category>> GetCategories()
        {
            var result1 = await _db.Categories.ToListAsync();

            return result1;

        }

        public async Task<Category> GetCategoryById(int Id)
        {
            var result = await _db.Categories.FirstOrDefaultAsync(cate => cate.CategoryId == Id);
            if (result == null)
                return null;
            return new Category
            {
                CategoryId = result.CategoryId,
                Name = result.Name,
                

            };
        }
    }
}
