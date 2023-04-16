using Microsoft.AspNetCore.Mvc;

namespace MosqueManagement.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
