using MosqueManagement.Models;

namespace MosqueManagement.Interfaces
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> GetAll();
        Task<Payment> GetByIdAsync(int paymentId);
        bool Add(Payment payment);
        bool Save();
    }
}
