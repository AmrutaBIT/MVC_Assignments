using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day_1AssignmentActionResult.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string tocheck)
        {
            if (tocheck == "sample")
                return File("~/sample.pdf", "application/pdf");
            else if(tocheck=="gotoabout")
                return RedirectToAction("About");
            else if(tocheck=="login")
                return RedirectToAction("Login");
            else
                return Content("You entered: " + tocheck);
            
        }
        public ActionResult About()
        {
            return Content("About Content Here!!");
        }
        public ActionResult Login()
        {
            return View();
        }
    }
}