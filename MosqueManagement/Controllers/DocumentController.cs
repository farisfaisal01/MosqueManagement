using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MosqueManagement.Data;
using MosqueManagement.Models;

namespace MosqueManagement.Controllers
{
    public class DocumentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DocumentController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var services = _context.Services.ToList();
            return View(services);
        }

        public IActionResult Detail(int serviceId)
        {
            Service service = _context.Services.FirstOrDefault(c => c.serviceId == serviceId);
            return View(service);
        }
    }
}
