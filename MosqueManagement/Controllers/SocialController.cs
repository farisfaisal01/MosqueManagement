using Microsoft.AspNetCore.Mvc;
using MosqueManagement.Data;
using MosqueManagement.Interfaces;
using MosqueManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace MosqueManagement.Controllers
{
    public class SocialController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly ISocialRepository _socialRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IWebHostEnvironment webHostEnvironment;
        public SocialController(ApplicationDbContext context, ISocialRepository socialRepository, IServiceRepository serviceRepository, IWebHostEnvironment webHost)
        {
            _context = context;
            _socialRepository = socialRepository;
            _serviceRepository = serviceRepository;
            webHostEnvironment = webHost;
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
            string fileName = null;
            if (social.socialAttachment != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Attachment");
                fileName = Guid.NewGuid().ToString() + "_" + social.socialAttachment.FileName;
                social.socialAttachmentPath = fileName;
                string filePath = Path.Combine(uploadsFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    social.socialAttachment.CopyTo(fileStream);
                }
            }
            _socialRepository.Add(social);
            TempData["CreateSuccessMessage"] = "Permohonan anda berjaya. Terima kasih!";
            return RedirectToAction("Index", "Document");
        }
    }
}
