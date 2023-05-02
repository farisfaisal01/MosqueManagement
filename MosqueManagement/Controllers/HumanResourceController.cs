using Microsoft.AspNetCore.Mvc;

namespace MosqueManagement.Controllers
{
    public class HumanResourceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
