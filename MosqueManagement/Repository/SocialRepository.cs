using Microsoft.EntityFrameworkCore;
using MosqueManagement.Data;
using MosqueManagement.Interfaces;
using MosqueManagement.Models;

namespace MosqueManagement.Repository
{
    public class SocialRepository : ISocialRepository
    {
        private readonly ApplicationDbContext _context;

        public SocialRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Social social)
        {
            _context.Add(social);
            return Save();
        }

        public async Task<IEnumerable<Social>> GetAll()
        {
            return await _context.Socials.ToListAsync();
        }

        public async Task<Social> GetByIdAsync(int socialId)
        {
            return await _context.Socials.FirstOrDefaultAsync(i => i.socialId == socialId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
