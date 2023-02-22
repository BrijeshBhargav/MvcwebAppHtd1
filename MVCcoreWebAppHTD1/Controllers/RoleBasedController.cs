using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using MVCcoreWebAppHTD1.Models;
using MVCcoreWebAppHTD1.BusinessLogic_bl;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Configuration;
namespace MVCcoreWebAppHTD1.Controllers
{
    public class RoleBasedController : Controller
    {


        [HttpGet]
        public IActionResult Access()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Access(RoleModel obj)
        {
            if (string.IsNullOrEmpty(obj.EmailID) && string.IsNullOrEmpty(obj.Password))
            {
                return RedirectToAction("Login");
            }
            ClaimsIdentity identity = null;
            bool isAuthentic = false;
            if (obj.EmailID == "admin@yahoo.com" && obj.Password == "admin")
            {
                identity = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.Name,obj.EmailID),
                    new Claim(ClaimTypes.Role,"Admin")
                    },
                     CookieAuthenticationDefaults.AuthenticationScheme);
                isAuthentic = true;
            }
            if (obj.EmailID == "user@yahoo.com" && obj.Password == "user")
            {
                identity = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.Name,obj.EmailID),
                    new Claim(ClaimTypes.Role,"User")
                    },
                     CookieAuthenticationDefaults.AuthenticationScheme);
                isAuthentic = true;
            }
            if (isAuthentic)
            {
                var principals = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principals);
                return RedirectToAction("Display", "RoleBased");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Display()
        {
              return View(Stdcurd_bl.GetAllData());
            }
          

        }


    }

