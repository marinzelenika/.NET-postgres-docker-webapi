using SampleAPI.Models;

namespace SampleAPI.Repositories
{
    public interface ITShirtRepository
    {
        Task<TShirt> GetTShirtByIdAsync(int id);
        Task<List<TShirt>> GetAllTShirtsAsync();
        Task<TShirt> AddAsync(TShirt tShirt);
        Task DeleteAsync(int id);
        Task<TShirt> UpdateAsync(TShirt tShirt);

    }
}
