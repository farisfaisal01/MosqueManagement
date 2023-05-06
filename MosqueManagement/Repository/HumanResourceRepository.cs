using Microsoft.EntityFrameworkCore;
using MosqueManagement.Data;
using MosqueManagement.Interfaces;
using MosqueManagement.Models;

namespace MosqueManagement.Repository
{
    public class HumanResourceRepository : IHumanResourceRepository
    {
        private readonly ApplicationDbContext _context;

        public HumanResourceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(HumanResource humanResource)
        {
            _context.Add(humanResource);
            return Save();
        }

        public bool Delete(HumanResource humanResource)
        {
            _context.Remove(humanResource);
            return Save();
        }

        public async Task<IEnumerable<HumanResource>> GetAll()
        {
            return await _context.HumanResources.ToListAsync();
        }

        public async Task<HumanResource> GetByIdAsync(int positionId)
        {
            return await _context.HumanResources.FirstOrDefaultAsync(i => i.positionId == positionId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(HumanResource humanResource)
        {
            _context.Update(humanResource);
            return Save();
        }
    }
}
