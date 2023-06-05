using MosqueManagement.Models;

namespace MosqueManagement.Interfaces
{
    public interface ISocialRepository
    {
        Task<IEnumerable<Social>> GetAll();
        Task<Social> GetByIdAsync(int socialId);
        bool Add(Social social);
        bool Update(Social social);
        bool Save();
    }
}
