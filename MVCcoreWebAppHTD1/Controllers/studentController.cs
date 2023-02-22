using Microsoft.AspNetCore.Mvc;
using MVCcoreWebAppHTD1.Models;
using MVCcoreWebAppHTD1.BusinessLogic_bl;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using static MVCcoreWebAppHTD1.Models.CalcModel;


namespace MVCcoreWebAppHTD1.Controllers
{
    public class studentController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Loginstudentdatamodel obj)
        {
            if (ModelState.IsValid)
            {
                DataTable dt = new DataTable();
                dt = Stdcurd_bl.Login(obj);
                if (dt.Rows.Count > 0)
                {
                    HttpContext.Session.SetString("UserName", dt.Rows[0]["Name"].ToString());
                    HttpContext.Session.SetString("Time", System.DateTime.Now.ToShortTimeString());

                    if (dt.Rows[0]["role"].ToString() == "student")
                    {
                        Random rnd = new Random();
                        HttpContext.Session.SetString("OTP", rnd.Next(111, 999).ToString());

                        bool result = SendEmail(obj.EmailId);
                        if (result == true)
                        {

                            return RedirectToAction("VerifyOTP", "student");
                        }

                    }
                    else if (dt.Rows[0]["role"].ToString() == "staff")
                    {
                        return RedirectToAction("AdminHome", "Admin");
                    }

                    return View();
                }

                else
                {
                    return View(obj);
                }

            }
            else
            {
                ModelState.AddModelError("", "error in saving data");
                return View();
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(studentdatamodel obj)
        {
            if (ModelState.IsValid)
            {
                bool res = Stdcurd_bl.InsertData(obj);
                if (res == true)
                {
                    return View("Login");
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
        public IActionResult forgotpassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult forgotpassword(studentdatamodel obj)
        {
            DataTable dt = new DataTable();
            dt = Stdcurd_bl.forgotpass(obj);
            if (dt.Rows.Count > 0)
            {
                Random rand = new Random();
                HttpContext.Session.SetString("OTP", rand.Next(1111, 9999).ToString());

                bool result = SendEmail(obj.EmailId);
                if (result == true)
                {
                    return RedirectToAction("VerifyOTP2", "student");
                }
                return View(obj);

            }
            else
            {
                return View(obj);
            }
        }

        [SetSessionGlobally]
        public IActionResult StudentHomePage()
        {

            return View();
        }
        public IActionResult dashboard()
        {
            return View();
        }
        [SetSessionGlobally]
        public IActionResult displaydata()
        {
            return View(Stdcurd_bl.GetAllData());
        }


        [HttpGet]
        public IActionResult check()
        {
            return View();
        }

        [HttpPost]
        public IActionResult check(checkdatamodel obj)
        {
            if (ModelState.IsValid)
            {
                bool res = Stdcurd_bl.InsertData(obj);
                if (res == true)
                {
                    return View("dashboard");
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
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "student");
        }
        public IActionResult Login2()
        {

            return View();
        }
        [HttpGet]
        public IActionResult Edit(int? RefID)
        {

            return View(Stdcurd_bl.GetDataByID((int)RefID));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(studentdatamodel obj)
        {
            if (ModelState.IsValid)
            {
                bool res = Stdcurd_bl.UpdateData(obj);
                if (res == true)
                {
                    return RedirectToAction("displaydata", "student");
                }
                else
                {
                    return View(obj);
                }
            }
            return View();
        }
        public IActionResult Delete(int? RefID)
        {
            bool res = Stdcurd_bl.DeleteData((int)RefID);
            if (res == true)
            {
                return RedirectToAction("displaydata");
            }
            else
            {
                return View();
            }
            return View();
        }

        public bool SendEmail(string receiver)
        {
            bool chk = false;
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("gollabrijesh2001@gmail.com");
                mail.To.Add(receiver);
                mail.IsBodyHtml = true;
                mail.Subject = "OTP";
                mail.Body = "Your Otp is :" + HttpContext.Session.GetString("OTP");

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.Credentials = new NetworkCredential("gollabrijesh2001@gmail.com","fqdjqilrcbytqvzz");
                client.EnableSsl = true;
                client.Send(mail);
                chk = true;
            }
            catch (Exception)
            {
                throw;
            }
            return chk;
        }
        [HttpGet]
        public IActionResult VerifyOTP()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult VerifyOTP(OTPModel obj)
        {
            if (obj.OTP.Equals(HttpContext.Session.GetString("OTP")))
            {
                return RedirectToAction("StudentHomePage", "student");
            }

            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Resetpassword(resetpasswordmodel obj)
        {

            if (ModelState.IsValid)
            {

                bool result = Stdcurd_bl.Resetpassword(obj);
                if (result == true)

                {
                    return RedirectToAction("Login", "student");
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
        public IActionResult VerifyOTP2()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult VerifyOTP2(otpmodel1 obj)
        {
            if (obj.otp.Equals(HttpContext.Session.GetString("OTP")))
            {
                return RedirectToAction("Resetpassword", "student");
            }

            else
            {
                return View();
            }
        }


        [HttpGet]
        public IActionResult bulkdata()
        {

            return View();
        }
        [HttpPost]
        public IActionResult bulkdata(string empdata)
        {
            if (ModelState.IsValid)
            {
                bool res = Stdcurd_bl.SaveBulkData(empdata);

                if (res == true)
                {
                    return View();
                }
                else { return View(empdata); }
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Checkdrop()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Checkdrop(checkboxModel1 obj)
        {
            if (ModelState.IsValid)
            {
                bool res = Stdcurd_bl.DROPDOWNcheckbox(obj);

                if (res == true)
                {
                    return RedirectToAction("StudentHomePage","student");
                }
                else
                {
                    return View(obj);
                }
            }
            else
            {
                return View();
            }

        }
        [HttpGet]
        public IActionResult IndexCalculator()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IndexCalculator(CalcModel2 obj)
        {
            if (ModelState.IsValid)
            {
                bool res = Stdcurd_bl.InsertCal1(obj);
                if (res == true)
                {
                    return View("Login");
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
        public IActionResult calculator()
        {
            return View();
        }
        [HttpPost]
        public IActionResult calculator(calculator3 obj)
        {
            if (ModelState.IsValid)
            {
                bool res = Stdcurd_bl.insertcalculator(obj);
                if (res == true)
                {

                    return View();

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
            return View();
        }
        public IActionResult Displaycal()
        {
            return View(Stdcurd_bl.GetALlData());
        }
    }

}



    


      


    



