using Microsoft.EntityFrameworkCore;
using MosqueManagement.Data;
using MosqueManagement.Interfaces;
using MosqueManagement.Migrations;
using MosqueManagement.Models;

namespace MosqueManagement.Repository
{
    public class RentalRepository : IRentalRepository
    {
        private readonly ApplicationDbContext _context;

        public RentalRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Rental rental)
        {
            _context.Add(rental);
            return Save();
        }

        public async Task<IEnumerable<Rental>> GetAll()
        {
            return await _context.Rentals.ToListAsync();
        }

        public async Task<Rental> GetByIdAsync(int rentalId)
        {
            return await _context.Rentals.FirstOrDefaultAsync(i => i.rentalId == rentalId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Rental rental)
        {
            _context.Update(rental);
            return Save();
        }
    }
}
