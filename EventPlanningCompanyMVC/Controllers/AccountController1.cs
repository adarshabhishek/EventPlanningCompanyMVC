using Microsoft.AspNetCore.Mvc;

namespace EventPlanningCompanyMVC.Controllers
{
    public class AccountController : Controller
    {
        // LOGIN PAGE
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // LOGIN POST
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // HARDCODED ADMIN CREDENTIALS

            if (username == "admin" && password == "admin123")
            {
                return RedirectToAction("Index", "Events");
            }

            ViewBag.Error = "Invalid Username or Password";

            return View();
        }
    }
}