using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment webHostEnvironment;
        public ClassController(ApplicationDbContext context, IClassRepository classRepository, IServiceRepository serviceRepository, IWebHostEnvironment webHost)
        {
            _context = context;
            _classRepository = classRepository;
            _serviceRepository = serviceRepository;
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
        public async Task<IActionResult> Index(Class @class)
        {
            if (!ModelState.IsValid)
            {
                return View(@class);
            }
            string fileName = null;
            if (@class.classAttachment != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Attachment");
                fileName = Guid.NewGuid().ToString() + "_" + @class.classAttachment.FileName;
                @class.classAttachmentPath = fileName;
                string filePath = Path.Combine(uploadsFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    @class.classAttachment.CopyTo(fileStream);
                }
            }
            _classRepository.Add(@class);
            TempData["CreateSuccessMessage"] = "Permohonan anda berjaya. Terima kasih!";
            return RedirectToAction("Index", "Document");
        }
    }
}
