using Microsoft.AspNetCore.Mvc;
using MosqueManagement.Data;

namespace MosqueManagement.Controllers
{
    public class HumanResourceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HumanResourceController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var humanresources = _context.HumanResources.ToList();
            return View(humanresources);
        }
    }
}
