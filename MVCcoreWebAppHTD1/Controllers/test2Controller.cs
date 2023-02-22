using Microsoft.AspNetCore.Mvc;
using MVCcoreWebAppHTD1.BusinessLogic_bl;
using MVCcoreWebAppHTD1.Models;

namespace MVCcoreWebAppHTD1.Controllers
{
    public class test2Controller : Controller
    {
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(InsertModel obj)
        {
            if (ModelState.IsValid)
            {
                bool res = Stdcurd_bl.InsertData2(obj);
                if (res == true)
                {
                    return RedirectToAction("Display", "test2");
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
        public IActionResult Edit(int? Id)
        {

            return View(Stdcurd_bl.GetDataByID2((int)Id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(InsertModel obj)
        {
            if (ModelState.IsValid)
            {
                bool res = Stdcurd_bl.UpdateData2(obj);
                if (res == true)
                {
                    return RedirectToAction("Display", "test2");
                }
                else
                {
                    return View(obj);
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult Display()
        {
            return View(Stdcurd_bl.GetAllData2());
        }
        public IActionResult Delete(int? Id)
        {
            bool res = Stdcurd_bl.Delete((int)Id);
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
     

    }
}
