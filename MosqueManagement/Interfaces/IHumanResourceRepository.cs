using MosqueManagement.Models;

namespace MosqueManagement.Interfaces
{
    public interface IHumanResourceRepository
    {
        Task<IEnumerable<HumanResource>> GetAll();
        Task<HumanResource> GetByIdAsync(int positionId);

        bool Add(HumanResource humanResource);
        bool Update(HumanResource humanResource);
        bool Delete(HumanResource humanResource);
        bool Save();
    }
}
