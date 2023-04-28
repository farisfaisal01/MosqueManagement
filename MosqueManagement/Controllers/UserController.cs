using Microsoft.AspNetCore.Mvc;
using MosqueManagement.Data;

namespace MosqueManagement.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            return View(users);
        }
    }
}
