using Microsoft.AspNetCore.Mvc;

namespace MVCcoreWebAppHTD1.Controllers
{
    public class DemoController : Controller
    {
        [HttpGet]
        public IActionResult test()
        {
            ViewBag.msg = "MVC";
            return View();
        }
        [HttpGet]
        public ActionResult addition()
        {
            ViewBag.msg = "addition logic";
            return View();
        }
        [HttpPost]
        public ActionResult addition(string obj)
        {

            int x = Convert.ToInt32(Request.Form["textval1"].ToString());
            int y = Convert.ToInt32(Request.Form["textval2"].ToString());
            int c = x + y;
            ViewBag.res = c;
            return View(ViewBag.res);
        }
        [HttpGet]
        public ActionResult multiplication()
        {
            ViewBag.msg = "multiplication logic";
            return View();
        }

        [HttpPost]
        public ActionResult multiplication(string obj)
        {
            int x = Convert.ToInt32(Request.Form["textval1"].ToString());
            int y = Convert.ToInt32(Request.Form["textval2"].ToString());
            int c = x * y;
            ViewBag.res = c;
            return View(ViewBag.res);
        }
        [HttpGet]
        public ActionResult substraction()
        {
            ViewBag.msg = "substract logic";
            return View();
        }

        [HttpPost]
        public ActionResult substraction(string obj)
        {
            int x = Convert.ToInt32(Request.Form["textval1"].ToString());
            int y = Convert.ToInt32(Request.Form["textval2"].ToString());
            int c = x - y;
            ViewBag.res = c;
            return View(ViewBag.res);
        }


    }
}
