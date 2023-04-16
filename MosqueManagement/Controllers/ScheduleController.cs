using Microsoft.AspNetCore.Mvc;

namespace MosqueManagement.Controllers
{
    public class ScheduleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
