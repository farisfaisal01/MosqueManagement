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
        private readonly IRentalRepository _rentalRepository;
        private readonly ISocialRepository _socialRepository;
        private readonly IClassRepository _classRepository;
        public PaymentController(ApplicationDbContext context, IPaymentRepository paymentRepository, IRentalRepository rentalRepository, ISocialRepository socialRepository, IClassRepository classRepository)
        {
            _context = context;
            _paymentRepository = paymentRepository;
            _rentalRepository = rentalRepository;
            _socialRepository = socialRepository;
            _classRepository = classRepository;
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


        //public async Task<IActionResult> ServicePay(int id)
        //{
        //    Rental rental = await _rentalRepository.GetByIdAsync(id);
        //    if (rental == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(rental);
        //}

        //[HttpPost]
        //public async Task<IActionResult> ServicePay(int id, Payment payment)
        //{
        //    Rental rental = await _rentalRepository.GetByIdAsync(id);
        //    if (id != rental.rentalId)
        //    {
        //        return NotFound();
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        return View(payment);
        //    }

        //    rental.paymentId = payment.paymentId; // Set the paymentId in the rental entity
        //    _paymentRepository.Add(payment);

        //    TempData["CreateSuccessMessage"] = "Pembayaran anda berjaya. Terima kasih!";
        //    return RedirectToAction("History");
        //}
    }
}
