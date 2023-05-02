using Microsoft.AspNetCore.Mvc;

namespace MosqueManagement.Controllers
{
    public class TabungController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
