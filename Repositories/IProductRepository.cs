using SampleAPI.Models;

namespace SampleAPI.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> AddAsync(Product Product);
        Task DeleteAsync(int id);
        Task<Product> UpdateAsync(Product Product);

    }
}
