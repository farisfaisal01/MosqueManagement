using MosqueManagement.Models;

namespace MosqueManagement.Interfaces
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> GetAll();
        Task<Payment> GetByIdAsync(int paymentId);

        bool Add(Payment payment);
        bool Update(Payment payment);
        bool Delete(Payment payment);
        bool Save();
    }
}
