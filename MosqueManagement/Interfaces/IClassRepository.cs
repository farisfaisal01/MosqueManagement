using MosqueManagement.Models;

namespace MosqueManagement.Interfaces
{
    public interface IClassRepository
    {
        Task<IEnumerable<Class>> GetAll();
        Task<Class> GetByIdAsync(int classId);
        bool Add(Class @class);
        bool Update(Class @class);
        bool Save();
    }
}
