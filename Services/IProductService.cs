using SampleAPI.DTOs;
using SampleAPI.Models;

namespace SampleAPI.Services
{
    public interface IProductService
    {
        Task<ProductDTO> GetProductByIdAsync(int id);
        Task<List<ProductDTO>> GetAllProductsAsync();
        Task<Product> AddAsync(ProductDTO ProductDto);
        Task DeleteAsync(int id);
        Task<Product> UpdateAsync(ProductDTO ProductDto);

    }
}
