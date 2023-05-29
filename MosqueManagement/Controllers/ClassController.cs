using Microsoft.AspNetCore.Mvc;
using MosqueManagement.Data;
using MosqueManagement.Interfaces;
using MosqueManagement.Models;
using MosqueManagement.Repository;

namespace MosqueManagement.Controllers
{
    public class ClassController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IClassRepository _classRepository;
        private readonly IServiceRepository _serviceRepository;
        public ClassController(ApplicationDbContext context, IClassRepository classRepository, IServiceRepository serviceRepository)
        {
            _context = context;
            _classRepository = classRepository;
            _serviceRepository = serviceRepository;
        }
        public async Task<IActionResult> Index(int id)
        {
            Service service = await _serviceRepository.GetByIdAsync(id);

            ViewData["Service"] = service;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Class @class)
        {
            if (!ModelState.IsValid)
            {
                return View(@class);
            }
            _classRepository.Add(@class);
            TempData["CreateSuccessMessage"] = "Permohonan anda berjaya. Terima kasih!";
            return RedirectToAction("Index", "Document");
        }
    }
}
