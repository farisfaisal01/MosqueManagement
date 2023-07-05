using MosqueManagement.Models;

namespace MosqueManagement.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetByIdAsync(int userId);
        Task<User> GetByEmailAsync(string email);
        bool Add(User user);
        bool Update(User user);
        bool Save();
    }
}
