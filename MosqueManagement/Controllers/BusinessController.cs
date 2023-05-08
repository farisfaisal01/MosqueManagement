using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> AdminIndex()
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
            return RedirectToAction("AdminIndex");
        }

        public async Task<IActionResult> Update(int id)
        {
            Market market = await _marketRepository.GetByIdAsync(id);
            if (market == null)
            {
                return NotFound();
            }
            return View(market);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, Market market)
        {
            if (id != market.marketId)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View(market);
            }
            try
            {
                _marketRepository.Update(market);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_marketRepository.GetByIdAsync(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("AdminIndex");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var market = await _marketRepository.GetByIdAsync(id);
            if (market == null)
            {
                return NotFound();
            }

            return View("Delete", market);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Market market)
        {
            //var market = await _marketRepository.GetByIdAsync(id);
            if (market == null)
            {
                return NotFound();
            }

            _marketRepository.Delete(market);
            return RedirectToAction("AdminIndex");
        }
    }
}
