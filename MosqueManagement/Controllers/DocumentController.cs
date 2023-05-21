using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MosqueManagement.Data;
using MosqueManagement.Interfaces;
using MosqueManagement.Models;
using MosqueManagement.Repository;

namespace MosqueManagement.Controllers
{
    public class DocumentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IServiceRepository _serviceRepository;

        public DocumentController(ApplicationDbContext context, IServiceRepository serviceRepository)
        {
            _context = context;
            _serviceRepository = serviceRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Service> services = await _serviceRepository.GetAll();
            return View(services);
        }
        public async Task<IActionResult> AdminIndex()
        {
            IEnumerable<Service> services = await _serviceRepository.GetAll();
            return View(services);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Service service = await _serviceRepository.GetByIdAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        public async Task<IActionResult> DetailAdmin(int id)
        {
            Service service = await _serviceRepository.GetByIdAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Service service)
        {
            if (!ModelState.IsValid)
            {
                return View(service);
            }
            _serviceRepository.Add(service);
            TempData["CreateSuccessMessage"] = "Data servis berjaya ditambah!";
            return RedirectToAction("AdminIndex");
        }

        public async Task<IActionResult> Update(int id)
        {
            Service service = await _serviceRepository.GetByIdAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, Service service)
        {
            if (id != service.serviceId)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View(service);
            }
            try
            {
                _serviceRepository.Update(service);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_serviceRepository.GetByIdAsync(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            TempData["UpdateSuccessMessage"] = "Deskripsi servis berjaya diubah!";
            return RedirectToAction("AdminIndex");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var service = await _serviceRepository.GetByIdAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, Service service)
        {
            if (service == null)
            {
                return NotFound();
            }

            _serviceRepository.Delete(service);
            TempData["DeleteSuccessMessage"] = "Data servis berjaya dipadam!";
            return RedirectToAction("AdminIndex");
        }
    }
}
