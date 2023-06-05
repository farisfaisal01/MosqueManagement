using MosqueManagement.Models;

namespace MosqueManagement.Interfaces
{
    public interface IRentalRepository
    {
        Task<IEnumerable<Rental>> GetAll();
        Task<Rental> GetByIdAsync(int rentalId);
        bool Add(Rental rental);
        bool Update(Rental rental);
        bool Save();
    }
}
