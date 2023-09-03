using HCI_Djole.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HCI_Djole.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IFlightService _flightService;
        public UserController(SignInManager<IdentityUser> signInManager, IFlightService flightService)
        {
            _signInManager = signInManager;
            _flightService = flightService;
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            TempData["success"] = true;
            TempData["message"] = "Uspešno ste se odjavili";

            return RedirectToAction("Flights", "Home");
        }
        public async Task<IActionResult> MyTickets()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var tickets = await _flightService.GetCustomerTickets(userId);
            return View(tickets);
        }
        public async Task<IActionResult> ReserveFlight(int flightId)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await _flightService.ReserveFlightForCustomer(flightId, userId);
                return Json(new { success = "true" });
            }
            catch(Exception ex)
            {
                return Json(new { error = ex.Message, success = "false" });
            }
        }
        public async Task<IActionResult> CancelFlight(int ticketId)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await _flightService.CancelCustomerFlight(ticketId, userId);
                return Json(new { success = "true" });
            }
            catch(Exception ex)
            {
                return Json(new { error = ex.Message, success = "false" });
            }
        }
        public async Task<IActionResult> GradeFlight(int flightId, int grade, string comment)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await _flightService.GradeFlight(flightId, grade, comment, userId);
                return Json(new { success = "true" });
            }
            catch(Exception ex)
            {
                return Json(new { success = "false", error = ex.Message });
            }
        }
    }
}