using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HCI_Djole.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        public UserController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            TempData["success"] = true;
            TempData["message"] = "Uspešno ste se odjavili";

            return RedirectToAction("Flights", "Home");
        }
    }
}
