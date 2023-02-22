using Microsoft.AspNetCore.Mvc;
using MVCcoreWebAppHTD1.Models;
using MVCcoreWebAppHTD1.BusinessLogic_bl;
namespace MVCcoreWebAppHTD1.Controllers
{
    public class DDLController : Controller
    {
        [HttpGet]
        public IActionResult ViewDropDown()
        {
            ViewBag.data = ddl_bl.PopulateData();
            return View();
            
        }
        [HttpPost]
        public IActionResult ViewDropDown(string x)
        {
            ViewBag.data = Request.Form["test"].ToString() ;
            return View();

        }
        [HttpGet]
        public IActionResult GetDataonDDL()
        {

            ViewBag.data = ddl_bl.PopulateData();
            return View();
        }
        [HttpPost]
        public IActionResult GetDataonDDL(string x)
        {
            ViewData["Val"] = ddl_bl.GetOrdersByCust(Request.Form["test"].ToString());
            ViewBag.data = ddl_bl.PopulateData();
            return View();

        }

        [HttpGet]
        public IActionResult viewOrder()
        {
            ViewBag.data = ddl_bl.PopData();
            return View();

        }
        [HttpPost]
        public IActionResult vieworder(string x)
        {
            ViewBag.data = Request.Form["test"].ToString();
            return View();

        }
        [HttpGet]
        public IActionResult GetOrderDDL()
        {

            ViewBag.data = ddl_bl.PopData();
            return View();
        }
        [HttpPost]
        public IActionResult GetOrderDDL(string x)
        {
            //ViewData["Val"] = ddl_bl.GetdatByOrder (Request.Form["test"]);
            //ViewData["Value"] = ddl_bl.GetdatByOrder(Request.Form["demo"]);

            ViewBag.data = ddl_bl.PopData();
            return View();

        }
        [HttpGet]
        public IActionResult ViewCoun()
        {
            ViewBag.data = ddl_bl.Popcoun();
            return View();

        }
        [HttpPost]
        public IActionResult ViewCoun(string x)
        {
            ViewBag.data = Request.Form["test"].ToString();
            return View();

        }
        [HttpGet]
        public IActionResult GetCounonDDL()
        {

            ViewBag.data = ddl_bl.Popcoun();
            return View();
        }
        [HttpPost]
        public IActionResult GetCounonDDL(string x)
        {
            ViewData["Val"] = ddl_bl.GetCoun(Request.Form["test"].ToString());
            ViewBag.data = ddl_bl.Popcoun();
            return View();

        }
       
        [HttpGet]
        public IActionResult GetDataonShip()
        {

            ViewBag.data = ddl_bl.ShipData();
            return View();
        }
        [HttpPost]
        public IActionResult GetDataonShip(DateTime x)
        {
            ViewData["Val"] = ddl_bl.GetorderbyShip(Convert.ToDateTime(Request.Form["test"].ToString()));
            ViewBag.data = ddl_bl.ShipData();
            return View();
        
        }

    }


}
