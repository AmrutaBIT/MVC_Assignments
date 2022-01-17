using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UdemyPractise.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult LoginData(string username, string password)
        {
            if(username=="Admin" && password == "admin123") 
                return RedirectToAction("dashboard", "Admin"); 

            else 
                return RedirectToAction("InvalidLogin");    
            
        }
        public ActionResult InvalidLogin(string username, string password)
        {
            return Content("Invalid Login Try Again");
        }
    }
}