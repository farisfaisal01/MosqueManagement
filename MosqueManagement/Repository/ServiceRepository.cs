using Microsoft.EntityFrameworkCore;
using MosqueManagement.Data;
using MosqueManagement.Interfaces;
using MosqueManagement.Models;

namespace MosqueManagement.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ApplicationDbContext _context;

        public ServiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Service service)
        {
            _context.Add(service);
            return Save();
        }

        public bool Delete(Service service)
        {
            _context.Remove(service);
            return Save();
        }

        public async Task<IEnumerable<Service>> GetAll()
        {
            return await _context.Services.ToListAsync();
        }

        public async Task<Service> GetByIdAsync(int serviceId)
        {
            return await _context.Services.FirstOrDefaultAsync(i => i.serviceId == serviceId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Service service)
        {
            _context.Update(service);
            return Save();
        }
    }
}
