using Microsoft.EntityFrameworkCore;
using MosqueManagement.Data;
using MosqueManagement.Interfaces;
using MosqueManagement.Models;

namespace MosqueManagement.Repository
{
    public class MarketRepository : IMarketRepository
    {
        private readonly ApplicationDbContext _context;

        public MarketRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Market market)
        {
            _context.Add(market);
            return Save();
        }

        public bool Delete(Market market)
        {
            _context.Remove(market);
            return Save();
        }

        public bool Update(Market market)
        {
            _context.Update(market);
            return Save();
        }

        public async Task<IEnumerable<Market>> GetAll()
        {
            return await _context.Markets.ToListAsync();
        }

        public async Task<Market> GetByIdAsync(int marketId)
        {
            return await _context.Markets.FirstOrDefaultAsync(i => i.marketId == marketId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
