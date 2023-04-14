using Mapster;
using SampleAPI.DTOs;
using SampleAPI.Models;
using SampleAPI.Repositories;

namespace SampleAPI.Services
{
    public class TShirtService : ITShirtService
    {
        private readonly ITShirtRepository _repository;

        public TShirtService(ITShirtRepository repository)
        {
            _repository = repository;
        }

        public async Task<TShirtDTO> GetTShirtByIdAsync(int id)
        {
            var tshirt = await _repository.GetTShirtByIdAsync(id);
            return tshirt.Adapt<TShirtDTO>();
        }

        public async Task<List<TShirtDTO>> GetAllTShirtsAsync()
        {
            var tshirts = await _repository.GetAllTShirtsAsync();
            return tshirts.Adapt<List<TShirtDTO>>();
        }
        public async Task<TShirt> AddAsync(TShirtDTO tShirtDto)
        {
            TShirt tShirt = new TShirt
            {
                CategoryID = tShirtDto.CategoryID,
                Name = tShirtDto.Name,
                Description = tShirtDto.Description,
                ImageUrl = tShirtDto.ImageUrl,
                Price = tShirtDto.Price,
                Stock = tShirtDto.Stock,
                Sizes = tShirtDto.Sizes
            };

            return await _repository.AddAsync(tShirt);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<TShirt> UpdateAsync(TShirtDTO tShirtDto)
        {
            TShirt tShirt = tShirtDto.Adapt<TShirt>();
            return await _repository.UpdateAsync(tShirt);
        }


    }
}
