using MosqueManagement.Models;

namespace MosqueManagement.Interfaces
{
    public interface IMarketRepository
    {
        Task<IEnumerable<Market>> GetAll();
        Task<Market> GetByIdAsync(int marketId);

        bool Add(Market market);
        bool Update(Market market);
        bool Delete(Market market);
        bool Save();
    }
}
