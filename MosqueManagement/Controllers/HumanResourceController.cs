using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MosqueManagement.Data;
using MosqueManagement.Interfaces;
using MosqueManagement.Models;
using MosqueManagement.Repository;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.IO.Pipes;

namespace MosqueManagement.Controllers
{
    public class HumanResourceController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHumanResourceRepository _humanResourceRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public HumanResourceController(ApplicationDbContext context, IHumanResourceRepository humanResourceRepository, IWebHostEnvironment webHost)
        {
            _context = context;
            _humanResourceRepository = humanResourceRepository;
            webHostEnvironment = webHost;
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
            string fileName = null;
            if (humanResource.staffImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Assets");
                fileName = Guid.NewGuid().ToString() + "_" + humanResource.staffImage.FileName;
                humanResource.staffImagePath = fileName;
                string filePath = Path.Combine(uploadsFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    humanResource.staffImage.CopyTo(fileStream);
                }
            }
            _humanResourceRepository.Add(humanResource);
            TempData["CreateSuccessMessage"] = "Data perniagaan berjaya ditambah!";
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
                if (humanResource.updatedStaffImage != null)
                {
                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Assets");
                    string fileName = Guid.NewGuid().ToString() + "_" + humanResource.updatedStaffImage.FileName;
                    string filePath = Path.Combine(uploadsFolder, fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await humanResource.updatedStaffImage.CopyToAsync(fileStream);
                    }

                    humanResource.staffImagePath = fileName;
                }

                _humanResourceRepository.Update(humanResource);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _humanResourceRepository.GetByIdAsync(id) == null)
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
            var humanResource = await _humanResourceRepository.GetByIdAsync(id);
            if (humanResource == null)
            {
                return NotFound();
            }

            return View(humanResource);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, HumanResource humanResource)
        {
            if (humanResource == null)
            {
                return NotFound();
            }

            // Delete the associated image file
            if (!string.IsNullOrEmpty(humanResource.staffImagePath))
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Assets");
                string filePath = Path.Combine(uploadsFolder, humanResource.staffImagePath);

                // Delete the image file
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }

            _humanResourceRepository.Delete(humanResource);
            TempData["DeleteSuccessMessage"] = "Data perniagaan berjaya dipadam!";
            return RedirectToAction("AdminIndex");
        }
    }
}
