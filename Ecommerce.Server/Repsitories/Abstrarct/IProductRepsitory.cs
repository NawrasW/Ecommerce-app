using Ecommerce.Server.Models.Domain;

namespace Ecommerce.Server.Repsitories.Abstrarct
{
    public interface IProductRepsitory
    {

        Task<Product> GetById(int id);

        Task<List<Product>> GetAll();

        Task<bool> AddUpdate(Product item);

        Task<bool> Delete(int Id);

        Task<List<Product>> GetProductsByCategoryId(int CategoryId);

    }
}
