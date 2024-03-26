using Ecommerce.Server.Models.Domain;

namespace Ecommerce.Server.Repsitories.Abstrarct
{
    public interface ICategoryRepsitory
    {


        public Task<Category> GetCategoryById(int Id);
        public Task<bool> AddUpdateCategory(Category user);

        public Task<List<Category>> GetAllCategory();


        public Task<List<Category>> GetAllCategoryLookup();

        public Task<bool> DeleteCategory(int Id);

        Task<List<Category>> GetCategories();
    }
}
