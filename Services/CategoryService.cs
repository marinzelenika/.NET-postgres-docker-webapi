using Mapster;
using SampleAPI.DTOs;
using SampleAPI.Models;
using SampleAPI.Repositories;

namespace SampleAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _repository.GetAllCategoriesAsync();
        }

        public async Task<Category> AddAsync(CategoryDTO categoryDto)
        {
            Category category = new Category
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description
            };
            return await _repository.AddAsync(category);
        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(int id)
        {
            var category = await _repository.GetCategoryByIdAsync(id);
            return category.Adapt<CategoryDTO>();
        }
    }
}
