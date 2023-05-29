using Microsoft.AspNetCore.Mvc;
using MosqueManagement.Data;
using MosqueManagement.Interfaces;
using MosqueManagement.Models;
using MosqueManagement.Repository;

namespace MosqueManagement.Controllers
{
    public class RentalController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRentalRepository _rentalRepository;
        private readonly IServiceRepository _serviceRepository;
        public RentalController(ApplicationDbContext context, IRentalRepository rentalRepository, IServiceRepository serviceRepository)
        {
            _context = context;
            _rentalRepository = rentalRepository;
            _serviceRepository = serviceRepository;
        }
        public async Task<IActionResult> Index(int id)
        {
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
            _rentalRepository.Add(rental);
            TempData["CreateSuccessMessage"] = "Permohonan anda berjaya. Terima kasih!";
            return RedirectToAction("Index", "Document");
        }
    }
}
