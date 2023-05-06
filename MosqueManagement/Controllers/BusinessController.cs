using Microsoft.AspNetCore.Mvc;
using MosqueManagement.Data;
using MosqueManagement.Interfaces;
using MosqueManagement.Models;

namespace MosqueManagement.Controllers
{
    public class BusinessController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMarketRepository _marketRepository;

        public BusinessController(ApplicationDbContext context, IMarketRepository marketRepository)
        {
            _context = context;
            _marketRepository = marketRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Market> markets = await _marketRepository.GetAll();
            return View(markets);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Market market)
        {
            if (!ModelState.IsValid)
            {
                return View(market);
            }
            _marketRepository.Add(market);
            return RedirectToAction("Index");
        }
    }
}
