using SampleAPI.Models;

namespace SampleAPI.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> AddAsync(Category category);
        Task<Category> GetCategoryByIdAsync(int id);
    }
}
