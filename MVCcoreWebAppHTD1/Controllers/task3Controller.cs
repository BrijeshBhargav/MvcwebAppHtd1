using Microsoft.AspNetCore.Mvc;
using MVCcoreWebAppHTD1.BusinessLogic_bl;
using MVCcoreWebAppHTD1.Models;
using WebApplicationAzureTask.BusinessLogics_bl;

namespace MVCcoreWebAppHTD1.Controllers
{
    public class task3Controller : Controller
    {
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(BookModel obj)
        {
            if (ModelState.IsValid)
            {
                bool res = test2_bl.InsertData(obj);
                if (res == true)
                {
                    return RedirectToAction("Display", "task3");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }

        }
        [HttpGet]
        public IActionResult Display()
        {
            return View(test2_bl.GetAllData());
        }
        [HttpGet]
        public IActionResult Edit(int? BookId)
        {

            return View(test2_bl.GetDataByID((int)BookId));
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BookModel obj)
        {
            if (ModelState.IsValid)
            {
                bool res = test2_bl.UpdateData(obj);
                if (res == true)
                {
                    return RedirectToAction("Display");
                }
                else
                {
                    return View(obj);
                }
            }
            return View();
        }
     
        public IActionResult Delete(int? BookId)
        {
            bool res = test2_bl.DeleteData((int)BookId);
            if (res == true)
            {
                return RedirectToAction("Display");
            }
            else
            {
                return View();
            }
            return View();
        }

        public IActionResult Details(BookModel obj, int? BookId)
        {
            if (ModelState.IsValid)
            {
                bool res = (test2_bl.UpdateData(obj));
                if (res == true)
                {
                    return RedirectToAction("Display");
                }
                else
                {
                    return View(obj);
                }
            }
            return View(test2_bl.GetDataByID((int)BookId));
        }
    }
}


    
