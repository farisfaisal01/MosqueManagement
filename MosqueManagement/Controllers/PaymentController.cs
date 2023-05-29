using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MosqueManagement.Data;
using MosqueManagement.Interfaces;
using MosqueManagement.Models;
using MosqueManagement.Repository;

namespace MosqueManagement.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaymentRepository _paymentRepository;
        public PaymentController(ApplicationDbContext context, IPaymentRepository paymentRepository)
        {
            _context = context;
            _paymentRepository = paymentRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Payment payment)
        {
            if (!ModelState.IsValid)
            {
                return View(payment);
            }
            _paymentRepository.Add(payment);
            TempData["CreateSuccessMessage"] = "Pembayaran anda berjaya. Terima kasih!";
            return RedirectToAction("Index");
        }
    }
}
