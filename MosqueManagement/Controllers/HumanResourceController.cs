using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MosqueManagement.Data;
using MosqueManagement.Interfaces;
using MosqueManagement.Models;
using MosqueManagement.Repository;

namespace MosqueManagement.Controllers
{
    public class HumanResourceController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHumanResourceRepository _humanResourceRepository;

        public HumanResourceController(ApplicationDbContext context, IHumanResourceRepository humanResourceRepository)
        {
            _context = context;
            _humanResourceRepository = humanResourceRepository;
        }
        public IActionResult Index()
        {
            var humanresources = _context.HumanResources.ToList();
            return View(humanresources);
        }
        public IActionResult AdminIndex()
        {
            var humanresources = _context.HumanResources.ToList();
            return View(humanresources);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(HumanResource humanResource)
        {
            if (!ModelState.IsValid)
            {
                return View(humanResource);
            }
            _humanResourceRepository.Add(humanResource);
            return RedirectToAction("AdminIndex");
        }

        public async Task<IActionResult> Update(int id)
        {
            HumanResource humanResource = await _humanResourceRepository.GetByIdAsync(id);
            if (humanResource == null)
            {
                return NotFound();
            }
            return View(humanResource);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, HumanResource humanResource)
        {
            if (id != humanResource.positionId)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View(humanResource);
            }
            try
            {
                _humanResourceRepository.Update(humanResource);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_humanResourceRepository.GetByIdAsync(id) == null)
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
    }
}
