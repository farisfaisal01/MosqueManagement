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
    public class DocumentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IServiceRepository _serviceRepository;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IRentalRepository _rentalRepository;
        private readonly ISocialRepository _socialRepository;
        private readonly IClassRepository _classRepository;

        public DocumentController(ApplicationDbContext context, IServiceRepository serviceRepository, IWebHostEnvironment webHost, IRentalRepository rentalRepository, ISocialRepository socialRepository, IClassRepository classRepository)
        {
            _context = context;
            _serviceRepository = serviceRepository;
            webHostEnvironment = webHost;
            _rentalRepository = rentalRepository;
            _socialRepository = socialRepository;
            _classRepository = classRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Service> services = await _serviceRepository.GetAll();
            return View(services);
        }
        public async Task<IActionResult> AdminIndex()
        {
            IEnumerable<Service> services = await _serviceRepository.GetAll();
            return View(services);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Service service = await _serviceRepository.GetByIdAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        public async Task<IActionResult> DetailAdmin(int id)
        {
            Service service = await _serviceRepository.GetByIdAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Service service)
        {
            if (!ModelState.IsValid)
            {
                return View(service);
            }
            string fileName = null;
            if (service.serviceAttachment != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Assets");
                fileName = Guid.NewGuid().ToString() + "_" + service.serviceAttachment.FileName;
                service.serviceImagePath = fileName;
                string filePath = Path.Combine(uploadsFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    service.serviceAttachment.CopyTo(fileStream);
                }
            }
            _serviceRepository.Add(service);
            TempData["CreateSuccessMessage"] = "Data perkhidmatan berjaya ditambah!";
            return RedirectToAction("AdminIndex");
        }

        public async Task<IActionResult> Update(int id)
        {
            Service service = await _serviceRepository.GetByIdAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, Service service)
        {
            if (id != service.serviceId)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View(service);
            }

            try
            {
                if (service.updatedServiceAttachment != null)
                {
                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Assets");
                    string fileName = Guid.NewGuid().ToString() + "_" + service.updatedServiceAttachment.FileName;
                    string filePath = Path.Combine(uploadsFolder, fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await service.updatedServiceAttachment.CopyToAsync(fileStream);
                    }

                    service.serviceImagePath = fileName;
                }

                _serviceRepository.Update(service);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _serviceRepository.GetByIdAsync(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            TempData["UpdateSuccessMessage"] = "Perincian perkhidmatan berjaya diubah!";
            return RedirectToAction("AdminIndex");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var service = await _serviceRepository.GetByIdAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, Service service)
        {
            if (service == null)
            {
                return NotFound();
            }

            // Delete the associated image file
            if (!string.IsNullOrEmpty(service.serviceImagePath))
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Assets");
                string filePath = Path.Combine(uploadsFolder, service.serviceImagePath);

                // Delete the image file
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }
            _serviceRepository.Delete(service);
            TempData["DeleteSuccessMessage"] = "Data perkhidmatan berjaya dipadam!";
            return RedirectToAction("AdminIndex");
        }

        public async Task<IActionResult> Approve()
        {
            IEnumerable<Service> services = await _serviceRepository.GetAll();
            IEnumerable<Rental> rentals = await _rentalRepository.GetAll();
            IEnumerable<Social> socials = await _socialRepository.GetAll();
            IEnumerable<Class> classes = await _classRepository.GetAll();

            ViewData["Services"] = services;
            ViewData["Rentals"] = rentals;
            ViewData["Socials"] = socials;
            ViewData["Classes"] = classes;

            return View();
        }

        public async Task<IActionResult> RentalApproval(int id)
        {
            Rental rental = await _rentalRepository.GetByIdAsync(id);
            if (rental == null)
            {
                return NotFound();
            }
            return View(rental);
        }

        [HttpPost]
        public async Task<IActionResult> RentalApproval(int id, Rental rental)
        {
            if (id != rental.rentalId)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View(rental);
            }
            _rentalRepository.Update(rental);

            TempData["UpdateSuccessMessage"] = "Keputusan disahkan!";
            return RedirectToAction("Approve");
        }

        public async Task<IActionResult> SocialApproval(int id)
        {
            Social social = await _socialRepository.GetByIdAsync(id);
            if (social == null)
            {
                return NotFound();
            }
            return View(social);
        }

        [HttpPost]
        public async Task<IActionResult> SocialApproval(int id, Social social)
        {
            if (id != social.socialId)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View(social);
            }
            _socialRepository.Update(social);

            TempData["UpdateSuccessMessage"] = "Keputusan disahkan!";
            return RedirectToAction("Approve");
        }

        public async Task<IActionResult> ClassApproval(int id)
        {
            Class classes = await _classRepository.GetByIdAsync(id);
            if (classes == null)
            {
                return NotFound();
            }
            return View(classes);
        }

        [HttpPost]
        public async Task<IActionResult> ClassApproval(int id, Class classes)
        {
            if (id != classes.classId)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View(classes);
            }
            _classRepository.Update(classes);

            TempData["UpdateSuccessMessage"] = "Keputusan disahkan!";
            return RedirectToAction("Approve");
        }

        public async Task<IActionResult> AdminHistory()
        {
            IEnumerable<Service> services = await _serviceRepository.GetAll();
            IEnumerable<Rental> rentals = await _rentalRepository.GetAll();
            IEnumerable<Social> socials = await _socialRepository.GetAll();
            IEnumerable<Class> classes = await _classRepository.GetAll();

            ViewData["Services"] = services;
            ViewData["Rentals"] = rentals;
            ViewData["Socials"] = socials;
            ViewData["Classes"] = classes;

            return View();
        }

        public async Task<IActionResult> History()
        {
            IEnumerable<Service> services = await _serviceRepository.GetAll();
            IEnumerable<Rental> rentals = await _rentalRepository.GetAll();
            IEnumerable<Social> socials = await _socialRepository.GetAll();
            IEnumerable<Class> classes = await _classRepository.GetAll();

            ViewData["Services"] = services;
            ViewData["Rentals"] = rentals;
            ViewData["Socials"] = socials;
            ViewData["Classes"] = classes;

            return View();
        }

        public async Task<IActionResult> Statistic()
        {
            IEnumerable<Service> services = await _serviceRepository.GetAll();
            IEnumerable<Rental> rentals = await _rentalRepository.GetAll();
            IEnumerable<Social> socials = await _socialRepository.GetAll();
            IEnumerable<Class> classes = await _classRepository.GetAll();

            ViewData["Services"] = services;
            ViewData["Rentals"] = rentals;
            ViewData["Socials"] = socials;
            ViewData["Classes"] = classes;

            return View();
        }
    }
}
