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
        private readonly IServiceRepository _serviceRepository;
        private readonly ISocialRepository _socialRepository;
        private readonly IClassRepository _classRepository;
        public PaymentController(ApplicationDbContext context, IPaymentRepository paymentRepository, IServiceRepository serviceRepository, IRentalRepository rentalRepository, ISocialRepository socialRepository, IClassRepository classRepository)
        {
            _context = context;
            _paymentRepository = paymentRepository;
            _rentalRepository = rentalRepository;
            _socialRepository = socialRepository;
            _serviceRepository = serviceRepository;
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

        public async Task<IActionResult> RentalServicePay(int id)
        {
            Rental rental = await _rentalRepository.GetByIdAsync(id);

            if (rental == null)
            {
                return NotFound();
            }
            ViewData["Rental"] = rental;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RentalServicePay(Payment payment)
        {
            if (!ModelState.IsValid)
            {
                return View(payment);
            }
            _paymentRepository.Add(payment);

            TempData["CreateSuccessMessage"] = "Pembayaran anda berjaya. Terima kasih!";
            return RedirectToAction("RentalSuccess", "Document", new { id = payment.rentalId });
        }

        public async Task<IActionResult> SocialServicePay(int id)
        {
            Social social = await _socialRepository.GetByIdAsync(id);

            if (social == null)
            {
                return NotFound();
            }
            ViewData["Social"] = social;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SocialServicePay(Payment payment)
        {
            if (!ModelState.IsValid)
            {
                return View(payment);
            }
            _paymentRepository.Add(payment);

            TempData["CreateSuccessMessage"] = "Pembayaran anda berjaya. Terima kasih!";
            return RedirectToAction("SocialSuccess", "Document", new { id = payment.socialId });
        }

        public async Task<IActionResult> ClassServicePay(int id)
        {
            Class claases = await _classRepository.GetByIdAsync(id);

            if (claases == null)
            {
                return NotFound();
            }
            ViewData["Class"] = claases;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ClassServicePay(Payment payment)
        {
            if (!ModelState.IsValid)
            {
                return View(payment);
            }
            _paymentRepository.Add(payment);

            TempData["CreateSuccessMessage"] = "Pembayaran anda berjaya. Terima kasih!";
            return RedirectToAction("ClassSuccess", "Document", new { id = payment.classId });
        }
    }
}
