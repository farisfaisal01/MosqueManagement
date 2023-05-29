using Microsoft.EntityFrameworkCore;
using MosqueManagement.Data;
using MosqueManagement.Interfaces;
using MosqueManagement.Models;

namespace MosqueManagement.Repository
{
    public class ClassRepository : IClassRepository
    {
        private readonly ApplicationDbContext _context;

        public ClassRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Class @class)
        {
            _context.Add(@class);
            return Save();
        }

        public async Task<IEnumerable<Class>> GetAll()
        {
            return await _context.Classes.ToListAsync();
        }

        public async Task<Class> GetByIdAsync(int classId)
        {
            return await _context.Classes.FirstOrDefaultAsync(i => i.classId == classId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
