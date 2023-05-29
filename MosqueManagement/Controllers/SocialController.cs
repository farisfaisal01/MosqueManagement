using Microsoft.AspNetCore.Mvc;
using MosqueManagement.Data;
using MosqueManagement.Interfaces;
using MosqueManagement.Models;

namespace MosqueManagement.Controllers
{
    public class SocialController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly ISocialRepository _socialRepository;
        private readonly IServiceRepository _serviceRepository;
        public SocialController(ApplicationDbContext context, ISocialRepository socialRepository, IServiceRepository serviceRepository)
        {
            _context = context;
            _socialRepository = socialRepository;
            _serviceRepository = serviceRepository;
        }
        public async Task<IActionResult> Index(int id)
        {
            Service service = await _serviceRepository.GetByIdAsync(id);

            ViewData["Service"] = service;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Social social)
        {
            if (!ModelState.IsValid)
            {
                return View(social);
            }
            _socialRepository.Add(social);
            TempData["CreateSuccessMessage"] = "Permohonan anda berjaya. Terima kasih!";
            return RedirectToAction("Index", "Document");
        }
    }
}
