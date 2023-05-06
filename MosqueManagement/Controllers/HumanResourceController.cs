using Microsoft.AspNetCore.Mvc;
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
    }
}
