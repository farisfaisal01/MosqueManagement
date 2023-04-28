using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MosqueManagement.Data;

namespace MosqueManagement.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ScheduleController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var schedule = _context.Schedules.ToList();
            return View();
        }
    }
}
