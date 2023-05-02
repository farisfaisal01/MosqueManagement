using Microsoft.AspNetCore.Mvc;

namespace MosqueManagement.Controllers
{
    public class BusinessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
