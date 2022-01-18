using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day2AssignmentRazorView.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int amount)
        {
            ViewBag.amount=amount;
            return View();
        }
    }
}