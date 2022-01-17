using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UdemyPractise.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetEmpName(int empid)
        {
            var Employee = new[] {
                new { empid = 1, Empname = "Scott", Empsalary = 8000 },
                new { empid = 2, Empname = "John", Empsalary = 12000 },
                new { empid = 3, Empname = "Mark", Empsalary = 7000 }
            };
            string matchEmpName = null;
            foreach (var item in Employee)
            {
                if (item.empid == empid)
                {
                    matchEmpName = item.Empname;
                }

            }
            return Content(matchEmpName, "text/plain");

        }
        public ActionResult GetFile(int empid)
        {
            string filePath = "~/PaySlip"+ empid +".pdf";
            return File(filePath, "application/pdf");
        }
        public ActionResult EmpFacebookPage(int empid)
        {
            var Employee = new[] {
                new { empid = 1, Empname = "Scott", Empsalary = 8000 },
                new { empid = 2, Empname = "John", Empsalary = 12000 },
                new { empid = 3, Empname = "Mark", Empsalary = 7000 }
            };
            string fbUrl = null;
            foreach (var item in Employee)
            {
                if (item.empid == empid)
                {
                    fbUrl = "https://www.facebook.com/emp" + empid;
                }
            }
            if (fbUrl == null)
            {
                return Content("Invalid Emp ID");
            }
            else
            {
                return Redirect(fbUrl);
            }
        }
           
    }
}