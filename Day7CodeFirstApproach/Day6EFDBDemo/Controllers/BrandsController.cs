using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Day6EFDBDemo.Models;

namespace Day6EFDBDemo.Controllers
{
    public class BrandsController : Controller
    {
        public ActionResult Index()
        {
            CompanyDbContext db = new CompanyDbContext();
            List<Brand> brands =  db.Brands.ToList();
            return View(brands);
        }
    }
}