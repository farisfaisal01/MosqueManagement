using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MosqueManagement.Data;
using MosqueManagement.Interfaces;
using MosqueManagement.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.IO.Pipes;

namespace MosqueManagement.Controllers
{
    public class BusinessController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMarketRepository _marketRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public BusinessController(ApplicationDbContext context, IMarketRepository marketRepository, IWebHostEnvironment webHost)
        {
            _context = context;
            _marketRepository = marketRepository;
            webHostEnvironment = webHost;
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
            string fileName = null;
            if (market.marketAttachment != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Assets");
                fileName = Guid.NewGuid().ToString() + "_" + market.marketAttachment.FileName;
                market.marketImagePath = fileName;
                string filePath = Path.Combine(uploadsFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    market.marketAttachment.CopyTo(fileStream);
                }
            }
            _marketRepository.Add(market);
            TempData["CreateSuccessMessage"] = "Data perniagaan berjaya ditambah!";
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
            TempData["UpdateSuccessMessage"] = "Perincian perniagaan berjaya diubah!";
            return RedirectToAction("AdminIndex");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var market = await _marketRepository.GetByIdAsync(id);
            if (market == null)
            {
                return NotFound();
            }

            return View(market);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, Market market)
        {
            if (market == null)
            {
                return NotFound();
            }

            _marketRepository.Delete(market);
            TempData["DeleteSuccessMessage"] = "Data perniagaan berjaya dipadam!";
            return RedirectToAction("AdminIndex");
        }
    }
}
