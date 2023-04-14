using SampleAPI.DTOs;
using SampleAPI.Models;

namespace SampleAPI.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<CategoryDTO> GetCategoryByIdAsync(int id);
        Task<Category> AddAsync(CategoryDTO categoryDto);
    }
}
