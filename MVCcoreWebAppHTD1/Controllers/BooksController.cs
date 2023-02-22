using Microsoft.AspNetCore.Mvc;
using MVCcoreWebAppHTD1.BusinessLogic_bl;
using MVCcoreWebAppHTD1.Models;
using WebApplicationAzureTask.BusinessLogics_bl;

namespace WebApplicationAzureTask.Controllers
    {
        public class BooksController : Controller
        {
            public IActionResult BookList()
            {
                return View(BooksLogics_bl.Getalldata());
            }
            [HttpGet]
            public IActionResult AddNewBooks()
            {
                return View();
            }
            [HttpPost]
            public IActionResult AddNewBooks(Books obj)
            {
                if (ModelState.IsValid)
                {
                    bool res = BooksLogics_bl.InsertData(obj);
                    if (res == true)
                    {

                        return RedirectToAction("BookList","Books");
                  
                    }
                    else
                    {
                        return View(obj);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Something went wrong");
                    return View(obj);
                }
            }
            public IActionResult Delete(int? ID)
            {
                bool res = BooksLogics_bl.deletedata((int)ID);
                if (res == true)
                {
                    return RedirectToAction("BookList");
                }
                else
                {
                    return View();
                }
                return View();
            }
            [HttpGet]
            public IActionResult Edit(int? ID)
            {
                return View(BooksLogics_bl.GetDataByID((int)ID));
            }
            [HttpPost]
            public IActionResult Edit(Books obj)
            {
                if (ModelState.IsValid)
                {
                    bool res = (BooksLogics_bl.UpdateData(obj));
                    if (res == true)
                    {
                        return RedirectToAction("BookList","Books");
                    }
                    else
                    {
                        return View(obj);
                    }
                }
                return View();
            }
            public IActionResult Details(Books obj, int? ID)
            {
                if (ModelState.IsValid)
                {
                    bool res = (BooksLogics_bl.UpdateData(obj));
                    if (res == true)
                    {
                        return RedirectToAction("BookList");
                    }
                    else
                    {
                        return View(obj);
                    }
                }
                return View(BooksLogics_bl.GetDataByID((int)ID));
            }
        }
    }

