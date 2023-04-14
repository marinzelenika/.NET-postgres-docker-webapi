using Microsoft.EntityFrameworkCore;
using sample_app.Data;
using SampleAPI.Models;

namespace SampleAPI.Repositories
{
    public class TShirtRepository : ITShirtRepository
    {
        private readonly MyDbContext _context;

        public TShirtRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<TShirt> GetTShirtByIdAsync(int id)
        {
            return await _context.TShirts.FindAsync(id);
        }

        public async Task<List<TShirt>> GetAllTShirtsAsync()
        {
            return await _context.TShirts.ToListAsync();
        }

        public async Task<TShirt> AddAsync(TShirt tShirt)
        {
            await _context.TShirts.AddAsync(tShirt);
            await _context.SaveChangesAsync();
            return tShirt;
        }

        public async Task DeleteAsync(int id)
        {
            var tShirt = await _context.TShirts.FindAsync(id);
            if (tShirt == null)
            {
                return;
            }

            _context.TShirts.Remove(tShirt);
            await _context.SaveChangesAsync();
        }

        public async Task<TShirt> UpdateAsync(TShirt tShirt)
        {
            _context.Entry(tShirt).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return tShirt;
        }



    }
}
