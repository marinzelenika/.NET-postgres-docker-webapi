using SampleAPI.DTOs;
using SampleAPI.Models;

namespace SampleAPI.Services
{
    public interface ITShirtService
    {
        Task<TShirtDTO> GetTShirtByIdAsync(int id);
        Task<List<TShirtDTO>> GetAllTShirtsAsync();
        Task<TShirt> AddAsync(TShirtDTO tShirtDto);
        Task DeleteAsync(int id);
        Task<TShirt> UpdateAsync(TShirtDTO tShirtDto);

    }
}
