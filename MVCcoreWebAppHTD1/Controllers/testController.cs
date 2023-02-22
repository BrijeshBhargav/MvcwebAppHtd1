using Microsoft.AspNetCore.Mvc;
using MVCcoreWebAppHTD1.Models;
using MVCcoreWebAppHTD1.BusinessLogic_bl;
namespace MVCcoreWebAppHTD1.Controllers
{
    public class testController : Controller
    {

        [HttpGet]
        public IActionResult ViewDropDown()
        {
            ViewBag.data = test_bl.carty();
            return View();

        }
        [HttpPost]
        public IActionResult ViewDropDown(string x)
        {
            ViewBag.data = Request.Form["test"].ToString();
            return View();

        }
        [HttpGet]
        public IActionResult GetDataoncar()
        {

            ViewBag.data = test_bl.carty();
            return View();
        }
        [HttpPost]
        public IActionResult GetDataoncar(string x)
        {
            ViewData["Val"] = test_bl.getbycar(Request.Form["test"].ToString());
            ViewBag.data = test_bl.carty();
            return View();

        }
        [HttpGet]
        public ActionResult Home()
        {
            return View();
        }
        [HttpGet]
        public ActionResult partial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult partial(partialModel obj)
        {
            ViewBag.Records = "Name : " + obj.Name + " City:  " + obj.City + " Addreess: " + obj.Address;
            return PartialView("Home");
        }
     
    }
}
