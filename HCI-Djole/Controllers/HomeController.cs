using HCI_Djole.Business.Dtos;
using HCI_Djole.Business.Interfaces;
using HCI_Djole.Models;
using HCI_Djole.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HCI_Djole.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFlightService _flightService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public HomeController(ILogger<HomeController> logger, IFlightService flightService, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _flightService = flightService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> FlightsAsync()
        {
            var model = new FlightsVM();
            model.Flights = await _flightService.GetAll();
            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate(LoginDto model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false });
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                TempData["Success"] = "False";
                TempData["Message"] = "Korisnik ne postoji";
            }
            else
            {
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                if (!result.Succeeded)
                {
                    TempData["Success"] = "False";
                    TempData["Message"] = "Pogrešna šifra, pokušajte ponovo";
                    return Json(new { });
                }
            }
            return RedirectToAction("Flights", "Home");
        }
    }
}