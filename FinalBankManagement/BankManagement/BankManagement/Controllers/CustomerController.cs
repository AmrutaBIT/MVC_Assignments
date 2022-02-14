using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankManagement.Models;


namespace BankManagement.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult Index(string CustomerName="", string PhoneNo="",string PolicyName="", string SortColumn = "CustomerNo", string IconClass = "fa-sort-asc", int PageNo = 1)
        {
            BankManagementDBEntities1 db = new BankManagementDBEntities1();
            List<Customer> customers = db.Customers.ToList();
            
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;
            ViewBag.PageNo = PageNo;
            

            if (ViewBag.SortColumn == "CustomerNo")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    customers = customers.OrderBy(temp => temp.CustomerNo).ToList();
                }
                else
                {
                    customers = customers.OrderByDescending(temp => temp.CustomerNo).ToList();
                }
            }
            else if (ViewBag.SortColumn == "CustomerName")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    customers = customers.OrderBy(temp => temp.CustomerName).ToList();
                }
                else
                {
                    customers = customers.OrderByDescending(temp => temp.CustomerName).ToList();
                }
            }
            else if (ViewBag.SortColumn == "PhoneNo")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    customers = customers.OrderBy(temp => temp.PhoneNo).ToList();
                }
                else
                {
                    customers = customers.OrderByDescending(temp => temp.PhoneNo).ToList();
                }
            }
            else if (ViewBag.SortColumn == "DateOfBirth")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    customers = customers.OrderBy(temp => temp.DateOfBirth).ToList();
                }
                else
                {
                    customers = customers.OrderByDescending(temp => temp.DateOfBirth).ToList();
                }
            }
            else if (ViewBag.SortColumn == "Address")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    customers = customers.OrderBy(temp => temp.Address).ToList();
                }
                else
                {
                    customers = customers.OrderByDescending(temp => temp.Address).ToList();
                }
            }
            else if (ViewBag.SortColumn == "Email")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    customers = customers.OrderBy(temp => temp.Email).ToList();
                }
                else
                {
                    customers = customers.OrderByDescending(temp => temp.Email).ToList();
                }
            }
            else if (ViewBag.SortColumn == "PolicyNo")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    customers = customers.OrderBy(temp => temp.PolicyDetail.PolicyName).ToList();
                }
                else
                {
                    customers = customers.OrderByDescending(temp => temp.PolicyDetail.PolicyName).ToList();
                }
            }

            int NoOfRecordsPerPage = 5;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(customers.Count) / Convert.ToDouble(NoOfRecordsPerPage)));
            int NoOfRecordsToSkip = (PageNo - 1) * NoOfRecordsPerPage;
            ViewBag.PageNo = PageNo;
            ViewBag.NoOfPages = NoOfPages;
            customers = customers.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();


            if (CustomerName != "" && PhoneNo != "" && PolicyName != "")
            {
                List<Customer> clist = db.Customers.Where(temp => temp.CustomerName.Contains(CustomerName) && temp.PhoneNo.Contains(PhoneNo) && temp.PolicyDetail.PolicyName.Contains(PolicyName)).ToList();
                int NoOfRecPerPage1 = 7;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(clist.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                ViewBag.pageno = PageNo;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.CustomerName = CustomerName;
                ViewBag.PhoneNo = PhoneNo;
                ViewBag.PolicyName = PolicyName;
                return View(clist);
            }
            else if (CustomerName != "" && PhoneNo != "")
            {
                List<Customer> clist = db.Customers.Where(temp =>temp.CustomerName.Contains(CustomerName) && temp.PhoneNo.Contains(PhoneNo)).ToList();
                int NoOfRecPerPage1 = 7;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(clist.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                ViewBag.pageno = PageNo;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.CustomerName = CustomerName;
                ViewBag.PhoneNo = PhoneNo;
                return View(clist);
            }
            else if (PolicyName != "" && PhoneNo != "")
            {
                List<Customer> clist = db.Customers.Where(temp => temp.PolicyDetail.PolicyName.Contains(PolicyName) && temp.PhoneNo.Contains(PhoneNo)).ToList();
                int NoOfRecPerPage1 = 7;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(clist.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                ViewBag.pageno = PageNo;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.PolicyName = PolicyName;
                ViewBag.PhoneNo = PhoneNo;
                return View(clist);
            }

            else if (PolicyName != "" && CustomerName != "")
            {
                List<Customer> clist = db.Customers.Where(temp => temp.PolicyDetail.PolicyName.Contains(PolicyName) && temp.CustomerName.Contains(CustomerName)).ToList();
                int NoOfRecPerPage1 = 7;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(clist.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                ViewBag.pageno = PageNo;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.PolicyName = PolicyName;
                ViewBag.CustomerName = CustomerName;
                return View(clist);
            }
            else if (PolicyName != "")
            {
                List<Customer> clist = db.Customers.Where(temp => temp.PolicyDetail.PolicyName.Contains(PolicyName)).ToList();
                int NoOfRecPerPage1 = 7;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(clist.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                ViewBag.pageno = PageNo;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.PolicyName = PolicyName;
                return View(clist);
            }
            else if (CustomerName != "")
            {
                List<Customer> clist = db.Customers.Where(temp => temp.CustomerName.Contains(CustomerName)).ToList();
                int NoOfRecPerPage1 = 7;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(clist.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                ViewBag.pageno = PageNo;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.CustomerName = CustomerName;
                return View(clist);
            }
            else if (PhoneNo != "")
            {
                List<Customer> clist = db.Customers.Where(temp =>  temp.PhoneNo.Contains(PhoneNo)).ToList();
                int NoOfRecPerPage1 = 7;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(clist.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                ViewBag.pageno = PageNo;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.PhoneNo = PhoneNo;
                return View(clist);
            }




            return View(customers);
        }

        public ActionResult Details(int id)
        {
            BankManagementDBEntities1 db = new BankManagementDBEntities1();
            Customer c = db.Customers.Where(temp => temp.CustomerNo == id).FirstOrDefault();
            return View(c);
        }

        public ActionResult Create()
        {
            BankManagementDBEntities1 db = new BankManagementDBEntities1();
            ViewBag.PolicyDetails = db.PolicyDetails.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer c)
        {
            BankManagementDBEntities1 db = new BankManagementDBEntities1();
            if (ModelState.IsValid)
            {
                if (Request.Files.Count >= 1)
                {
                    var file = Request.Files[0];
                    var imgBytes = new Byte[file.ContentLength];
                    file.InputStream.Read(imgBytes, 0, file.ContentLength);
                    var Base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                    c.Photo = Base64String;
                }

                db.Customers.Add(c);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.PolicyDetails = db.PolicyDetails.ToList();
                return View();
            }

        }

        public ActionResult Update(int id)
        {
            BankManagementDBEntities1 db = new BankManagementDBEntities1();
            Customer existingCustomer = db.Customers.Where(temp => temp.CustomerNo== id).FirstOrDefault();
            ViewBag.Customers = db.Customers.ToList();
            ViewBag.PolicyDetails = db.PolicyDetails.ToList();
            return View(existingCustomer);
        }

        [HttpPost]
        public ActionResult Update(Customer c)
        {
            BankManagementDBEntities1 db = new BankManagementDBEntities1();
            Customer existingCustomer = db.Customers.Where(temp => temp.CustomerNo == c.CustomerNo).FirstOrDefault();
            existingCustomer.CustomerName = c.CustomerName;
            existingCustomer.PhoneNo = c.PhoneNo;
            existingCustomer.DateOfBirth = c.DateOfBirth;
            existingCustomer.Address = c.Address;
            existingCustomer.Email = c.Email;
            existingCustomer.PolicyNo = c.PolicyNo;
            db.SaveChanges();
            return RedirectToAction("Index","Customer");
        }


        public JsonResult Delete(long id)
        {
            bool result = false;
            BankManagementDBEntities1 db = new BankManagementDBEntities1();
            Customer c = db.Customers.Where(temp => temp.CustomerNo == id).FirstOrDefault();
            db.Customers.Remove(c);
            db.SaveChanges();
            result = true;
            return Json(result, JsonRequestBehavior.AllowGet);


        }

    }
}