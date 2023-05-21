using MosqueManagement.Models;

namespace MosqueManagement.Interfaces
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetAll();
        Task<Service> GetByIdAsync(int serviceId);

        bool Add(Service service);
        bool Update(Service service);
        bool Delete(Service service);
        bool Save();
    }
}
