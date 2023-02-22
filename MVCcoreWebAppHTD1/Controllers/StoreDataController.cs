using Microsoft.AspNetCore.Mvc;
using MVCcoreWebAppHTD1.Models;
using System.Data;
namespace MVCcoreWebAppHTD1.Controllers
{
    public class StoreDataController : Controller
    {
        public IActionResult ExonViewData()
        {
            ViewData["vd"] = "I am Storing  Data using Viewdata";
            ViewBag.vb = "I am Storing  Data using ViewBag";
            TempData["td"] = "I am Storing  Data using Tempdata";
            return View();
        }
        public ActionResult ViewDataEx()
        {
            List<ViewDataModel> emplist=new List<Models.ViewDataModel>();
            emplist.Add(
                new ViewDataModel
                {
                    Eid = 1,
                    Name = "Brijesh",
                    Address = "hyd"
                });
            emplist.Add(
                new ViewDataModel
                {
                    Eid = 2,
                    Name = "xyz",
                    Address = "hyd"
                });
            emplist.Add(
                new ViewDataModel
                {
                    Eid = 3,
                    Name = "abc",
                    Address = "hyd"
                });
            ViewData["EmpList"]=emplist; 
            return View();
        }
        public IActionResult test()
        {
            return View();
        }
        }
    }

