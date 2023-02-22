using Microsoft.AspNetCore.Mvc;

namespace MVCcoreWebAppHTD1.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult AdminHome()
        {
            return View();
        }
        public IActionResult verifyuser()
        {
            return View();
        }
        public IActionResult adduser()
        {
            return View();
        }
    }
}
