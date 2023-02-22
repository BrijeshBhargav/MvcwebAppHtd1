
using Microsoft.AspNetCore.Mvc;
using MVCcoreWebAppHTD1.Models;
using MVCcoreWebAppHTD1.BusinessLogic_bl;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.Web;
using System.Linq;

namespace MVCcoreWebAppHTD1.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult BulkData()
        {
            List<Contactdata> customers = new List<Contactdata>();
            Contactdata obj = new Contactdata();
            customers.Add(obj);
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BulkData(Contactdata obj)
        {
            if (ModelState.IsValid)
            {
                bool res = Stdcurd_bl.contactdata(obj);
                if (res == true)
                {
                    return View("StudentHomePage");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View(obj);
            }


        }
        [HttpGet]
        public ActionResult index2()
        {
            return View();
        }
    }
}