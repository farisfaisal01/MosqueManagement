using Microsoft.AspNetCore.Mvc;
using MosqueManagement.Data;

namespace MosqueManagement.Controllers
{
    public class BusinessController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BusinessController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var markets = _context.Markets.ToList();
            return View(markets);
        }
    }
}
