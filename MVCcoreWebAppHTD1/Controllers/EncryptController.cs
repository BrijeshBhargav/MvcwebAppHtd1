using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using MVCcoreWebAppHTD1.Models;
using MVCcoreWebAppHTD1.BusinessLogic_bl;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Configuration;
namespace MVCcoreWebAppHTD1.Controllers
{
    public class EncryptController : Controller
    {
        [HttpGet]
        public IActionResult AddData()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddData(EncryptedModel obj)
        {
            if(ModelState.IsValid)
            {
                bool res=encrypt_bl.InsertData(obj);
                if(res==true)
                {
                    return RedirectToAction("Login","Encrypt");

                }
                else
                {
                    return View();
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(EncryptedModel obj)
        {
            if(ModelState.IsValid)
            {
                DataTable dt = new DataTable();
                dt = encrypt_bl.ReadData(obj);
                if(dt.Rows.Count>0)
                {
                    ViewData["EmailID"]= dt.Rows[0]["EmailID"].ToString();
                    ViewData["Password"] = dt.Rows[0]["Password"].ToString();
                }

            }
            return View();
        }
    }
}
