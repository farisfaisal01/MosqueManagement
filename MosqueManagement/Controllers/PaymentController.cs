﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MosqueManagement.Data;
using MosqueManagement.Interfaces;
using MosqueManagement.Models;
using MosqueManagement.Repository;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.IO.Pipes;
using Microsoft.AspNetCore.StaticFiles;
using MosqueManagement.Migrations;

namespace MosqueManagement.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IRentalRepository _rentalRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly ISocialRepository _socialRepository;
        private readonly IClassRepository _classRepository;
        private readonly IUserRepository _userRepository;
        private readonly IWebHostEnvironment webHostEnvironment;
        public PaymentController(ApplicationDbContext context, IPaymentRepository paymentRepository, IServiceRepository serviceRepository, IRentalRepository rentalRepository, ISocialRepository socialRepository, IClassRepository classRepository, IUserRepository userRepository, IWebHostEnvironment webHost)
        {
            _context = context;
            _paymentRepository = paymentRepository;
            _rentalRepository = rentalRepository;
            _socialRepository = socialRepository;
            _serviceRepository = serviceRepository;
            _classRepository = classRepository;
            _userRepository = userRepository;
            webHostEnvironment = webHost;
        }
        public async Task<IActionResult> Index()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            ViewBag.UserId = userId;
            User user = await _userRepository.GetByIdAsync(ViewBag.UserId);
            ViewData["User"] = user;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(MosqueManagement.Models.Payment payment)
        {
            if (!ModelState.IsValid)
            {
                return View(payment);
            }
            string fileName = null;
            if (payment.paymentAttachment != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "PaymentFile");
                fileName = Guid.NewGuid().ToString() + "_" + payment.paymentAttachment.FileName;
                payment.paymentAttachmentPath = fileName;
                string filePath = Path.Combine(uploadsFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    payment.paymentAttachment.CopyTo(fileStream);
                }
            }
            _paymentRepository.Add(payment);
            TempData["CreateSuccessMessage"] = "Pembayaran anda berjaya. Terima kasih!";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RentalServicePay(int id)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            ViewBag.UserId = userId;
            User user = await _userRepository.GetByIdAsync(ViewBag.UserId);
            ViewData["User"] = user;
            Rental rental = await _rentalRepository.GetByIdAsync(id);

            if (rental == null)
            {
                return NotFound();
            }
            ViewData["Rental"] = rental;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RentalServicePay(MosqueManagement.Models.Payment payment)
        {
            if (!ModelState.IsValid)
            {
                return View(payment);
            }
            string fileName = null;
            if (payment.paymentAttachment != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "PaymentFile");
                fileName = Guid.NewGuid().ToString() + "_" + payment.paymentAttachment.FileName;
                payment.paymentAttachmentPath = fileName;
                string filePath = Path.Combine(uploadsFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    payment.paymentAttachment.CopyTo(fileStream);
                }
            }
            _paymentRepository.Add(payment);

            TempData["CreateSuccessMessage"] = "Pembayaran anda berjaya. Terima kasih!";
            return RedirectToAction("RentalSuccess", "Document", new { id = payment.rentalId });
        }

        public async Task<IActionResult> SocialServicePay(int id)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            ViewBag.UserId = userId;
            User user = await _userRepository.GetByIdAsync(ViewBag.UserId);
            ViewData["User"] = user;
            Social social = await _socialRepository.GetByIdAsync(id);

            if (social == null)
            {
                return NotFound();
            }
            ViewData["Social"] = social;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SocialServicePay(MosqueManagement.Models.Payment payment)
        {
            if (!ModelState.IsValid)
            {
                return View(payment);
            }
            string fileName = null;
            if (payment.paymentAttachment != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "PaymentFile");
                fileName = Guid.NewGuid().ToString() + "_" + payment.paymentAttachment.FileName;
                payment.paymentAttachmentPath = fileName;
                string filePath = Path.Combine(uploadsFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    payment.paymentAttachment.CopyTo(fileStream);
                }
            }
            _paymentRepository.Add(payment);

            TempData["CreateSuccessMessage"] = "Pembayaran anda berjaya. Terima kasih!";
            return RedirectToAction("SocialSuccess", "Document", new { id = payment.socialId });
        }

        public async Task<IActionResult> ClassServicePay(int id)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            ViewBag.UserId = userId;
            User user = await _userRepository.GetByIdAsync(ViewBag.UserId);
            ViewData["User"] = user;
            Class claases = await _classRepository.GetByIdAsync(id);

            if (claases == null)
            {
                return NotFound();
            }
            ViewData["Class"] = claases;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ClassServicePay(MosqueManagement.Models.Payment payment)
        {
            if (!ModelState.IsValid)
            {
                return View(payment);
            }
            string fileName = null;
            if (payment.paymentAttachment != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "PaymentFile");
                fileName = Guid.NewGuid().ToString() + "_" + payment.paymentAttachment.FileName;
                payment.paymentAttachmentPath = fileName;
                string filePath = Path.Combine(uploadsFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    payment.paymentAttachment.CopyTo(fileStream);
                }
            }
            _paymentRepository.Add(payment);

            TempData["CreateSuccessMessage"] = "Pembayaran anda berjaya. Terima kasih!";
            return RedirectToAction("ClassSuccess", "Document", new { id = payment.classId });
        }
        public async Task<IActionResult> AdminTransaction()
        {
            IEnumerable<MosqueManagement.Models.Payment> payments = await _paymentRepository.GetAll();

            ViewData["Payments"] = payments;

            return View();
        }

        public async Task<IActionResult> Download(int id)
        {
            MosqueManagement.Models.Payment payment = await _paymentRepository.GetByIdAsync(id);

            if (payment != null && !string.IsNullOrEmpty(payment.paymentAttachmentPath))
            {
                string filePath = Path.Combine(webHostEnvironment.WebRootPath, "PaymentFile", payment.paymentAttachmentPath);

                if (System.IO.File.Exists(filePath))
                {
                    var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                    return File(fileStream, "application/octet-stream", payment.paymentAttachmentPath);
                }
            }

            return NotFound();
        }
    }
}
