using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankManagement.Models;

namespace BankManagement.Controllers
{
    public class PolicyController : Controller
    {
        public ActionResult Index()
        {
            BankManagementDBEntities1 db = new BankManagementDBEntities1();   
            List<PolicyDetail> policyDetails = db.PolicyDetails.ToList();
            return View(policyDetails);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PolicyDetail p)
        {
            BankManagementDBEntities1 db = new BankManagementDBEntities1();
            db.PolicyDetails.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult Delete(long id)
        {
            bool result = false;
            BankManagementDBEntities1 db = new BankManagementDBEntities1();
            PolicyDetail p = db.PolicyDetails.Where(temp => temp.PolicyNo == id).FirstOrDefault();
            db.PolicyDetails.Remove(p);
            db.SaveChanges();
            result = true;
            return Json(result, JsonRequestBehavior.AllowGet);


        }
    }
}