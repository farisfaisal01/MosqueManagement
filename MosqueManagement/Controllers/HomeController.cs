﻿using Microsoft.AspNetCore.Mvc;
using MosqueManagement.Data;
using MosqueManagement.Interfaces;
using MosqueManagement.Models;
using MosqueManagement.Repository;
using System.Diagnostics;
using BCrypt.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace MosqueManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IUserRepository _userRepository;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IUserRepository userRepository)
        {
            _logger = logger;
            _context = context;
            _userRepository = userRepository;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);

            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.password))
            {
                if (user.role == "user")
                {
                    HttpContext.Session.SetInt32("UserId", (int)user.userId);
                    return RedirectToAction("Index", "Home");
                }
                else if (user.role == "admin")
                {
                    return RedirectToAction("AdminIndex", "Home");
                }
            }

            // Invalid credentials or unknown role
            ModelState.AddModelError(string.Empty, "Email atau kata laluan salah");
            return View();
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<User> users = await _userRepository.GetAll();
                foreach (var item in users)
                {
                    if (string.Equals(item.email, user.email, StringComparison.OrdinalIgnoreCase))
                    {
                        ModelState.AddModelError(string.Empty, "User with this email already exists");
                        return View(user);
                    }
                }

                // Encrypt the password before storing it in the database
                user.password = BCrypt.Net.BCrypt.HashPassword(user.password);

                _userRepository.Add(user);

                return RedirectToAction("Login");
            }

            return View(user);
        }

        public IActionResult Index()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            ViewBag.UserId = userId;
            return View();
        }

        public IActionResult AdminIndex()
        {
            return View();
        }

        public IActionResult About()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            ViewBag.UserId = userId;
            return View();
        }

        public IActionResult AboutAdmin()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
        }

        public async Task<IActionResult> Profile()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            ViewBag.UserId = userId;
            User user = await _userRepository.GetByIdAsync(ViewBag.UserId);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(User user)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            ViewBag.UserId = userId;
            if (ViewBag.UserId != user.userId)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            user.password = BCrypt.Net.BCrypt.HashPassword(user.password);

            _userRepository.Update(user);
            

            TempData["UpdateSuccessMessage"] = "Perincian profil berjaya diubah!";
            return RedirectToAction("Profile");
        }

    }
}