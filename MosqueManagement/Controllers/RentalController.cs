using Microsoft.AspNetCore.Mvc;
using MosqueManagement.Data;
using MosqueManagement.Interfaces;
using MosqueManagement.Migrations;
using MosqueManagement.Models;
using MosqueManagement.Repository;

namespace MosqueManagement.Controllers
{
    public class RentalController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRentalRepository _rentalRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IWebHostEnvironment webHostEnvironment;
        public RentalController(ApplicationDbContext context, IRentalRepository rentalRepository, IServiceRepository serviceRepository, IPaymentRepository paymentRepository, IWebHostEnvironment webHost)
        {
            _context = context;
            _rentalRepository = rentalRepository;
            _serviceRepository = serviceRepository;
            _paymentRepository = paymentRepository;
            webHostEnvironment = webHost;
        }
        public async Task<IActionResult> Index(int id)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            ViewBag.UserId = userId;
            Service service = await _serviceRepository.GetByIdAsync(id);

            ViewData["Service"] = service;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Rental rental)
        {
            if (!ModelState.IsValid)
            {
                return View(rental);
            }
            string fileName = null;
            if (rental.rentalAttachment != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Attachment");
                fileName = Guid.NewGuid().ToString() + "_" + rental.rentalAttachment.FileName;
                rental.rentalAttachmentPath = fileName;
                string filePath = Path.Combine(uploadsFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    rental.rentalAttachment.CopyTo(fileStream);
                }
            }
            _rentalRepository.Add(rental);
            TempData["CreateSuccessMessage"] = "Permohonan anda berjaya. Terima kasih!";
            return RedirectToAction("Index", "Document");
        }
    }
}
