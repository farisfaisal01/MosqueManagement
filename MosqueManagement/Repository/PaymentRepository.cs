using Microsoft.EntityFrameworkCore;
using MosqueManagement.Data;
using MosqueManagement.Interfaces;
using MosqueManagement.Models;

namespace MosqueManagement.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Payment payment)
        {
            _context.Add(payment);
            return Save();
        }

        public bool Delete(Payment payment)
        {
            _context.Remove(payment);
            return Save();
        }

        public async Task<IEnumerable<Payment>> GetAll()
        {
            return await _context.Payments.ToListAsync();
        }

        public async Task<Payment> GetByIdAsync(int paymentId)
        {
            return await _context.Payments.FirstOrDefaultAsync(i => i.paymentId == paymentId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Payment payment)
        {
            _context.Update(payment);
            return Save();
        }
    }
}
