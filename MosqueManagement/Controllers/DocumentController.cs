using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MosqueManagement.Data;
using MosqueManagement.Interfaces;
using MosqueManagement.Models;
using MosqueManagement.Repository;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.IO.Pipes;

namespace MosqueManagement.Controllers
{
    public class DocumentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IServiceRepository _serviceRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public DocumentController(ApplicationDbContext context, IServiceRepository serviceRepository, IWebHostEnvironment webHost)
        {
            _context = context;
            _serviceRepository = serviceRepository;
            webHostEnvironment = webHost;
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
            string fileName = null;
            if (service.serviceAttachment != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Assets");
                fileName = Guid.NewGuid().ToString() + "_" + service.serviceAttachment.FileName;
                service.serviceImagePath = fileName;
                string filePath = Path.Combine(uploadsFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    service.serviceAttachment.CopyTo(fileStream);
                }
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
                if (service.updatedServiceAttachment != null)
                {
                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Assets");
                    string fileName = Guid.NewGuid().ToString() + "_" + service.updatedServiceAttachment.FileName;
                    string filePath = Path.Combine(uploadsFolder, fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await service.updatedServiceAttachment.CopyToAsync(fileStream);
                    }

                    service.serviceImagePath = fileName;
                }

                _serviceRepository.Update(service);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _serviceRepository.GetByIdAsync(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            TempData["UpdateSuccessMessage"] = "Perincian perniagaan berjaya diubah!";
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

            // Delete the associated image file
            if (!string.IsNullOrEmpty(service.serviceImagePath))
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Assets");
                string filePath = Path.Combine(uploadsFolder, service.serviceImagePath);

                // Delete the image file
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }
            _serviceRepository.Delete(service);
            TempData["DeleteSuccessMessage"] = "Data perniagaan berjaya dipadam!";
            return RedirectToAction("AdminIndex");
        }
    }
}
