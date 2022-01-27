using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Day6EFDBDemo.Models;

namespace Day6EFDBDemo.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index(string search= "", string SortColumn="productId", string IconClass= "fa-sort-asc",int PageNo=1)
        {
            EFDBDatabaseEntities db= new EFDBDatabaseEntities();
            //List<Product> products = db.Products.Where(temp =>temp.categoryId==1 && temp.price >10000).ToList();
            List<Product> products = db.Products.Where(temp => temp.productName.Contains(search)).ToList();
            ViewBag.search = search;
            
            //Sorting
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;
            if (ViewBag.SortColumn == "productId")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(temp => temp.productId).ToList();
                }
                else
                {
                    products = products.OrderByDescending(temp => temp.productId).ToList();
                }
            }
            else if (ViewBag.SortColumn == "productName")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(temp => temp.productName).ToList();
                }
                else
                {
                    products = products.OrderByDescending(temp => temp.productName).ToList();
                }
            }
            else if (ViewBag.SortColumn == "price")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(temp => temp.price).ToList();
                }
                else
                {
                    products = products.OrderByDescending(temp => temp.price).ToList();
                }
            }
            else if (ViewBag.SortColumn == "dateOfPurchase")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(temp => temp.dateOfPurchase).ToList();
                }
                else
                {
                    products = products.OrderByDescending(temp => temp.dateOfPurchase).ToList();
                }
            }
            else if (ViewBag.SortColumn == "availabilityStatus")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(temp => temp.availabilityStatus).ToList();
                }
                else
                {
                    products = products.OrderByDescending(temp => temp.availabilityStatus).ToList();
                }
            }
            else if (ViewBag.SortColumn == "categoryId")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(temp => temp.Category.categoryName).ToList();
                }
                else
                {
                    products = products.OrderByDescending(temp => temp.Category.categoryName).ToList();
                }
            }
            else if (ViewBag.SortColumn == "brandId")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(temp => temp.Brand.brandName).ToList();
                }
                else
                {
                    products = products.OrderByDescending(temp => temp.Brand.brandName).ToList();
                }
            }

            //Paging
            int NoOfRecordsPerPage = 5;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordsPerPage)));
            int NoOfRecordsToSkip = (PageNo - 1) * NoOfRecordsPerPage;
            ViewBag.PageNo = PageNo;
            ViewBag.NoOfPages = NoOfPages;
            products = products.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();
            return View(products);
        }

        public ActionResult Details(long id)
        {
            EFDBDatabaseEntities db = new EFDBDatabaseEntities();
            Product p = db.Products.Where(temp=> temp.productId==id).FirstOrDefault();
            return View(p);
        }

        public ActionResult Create()
        {
            EFDBDatabaseEntities db = new EFDBDatabaseEntities();
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product p)
        {
            EFDBDatabaseEntities db = new EFDBDatabaseEntities();
            if (Request.Files.Count >= 1)
            {
                var file = Request.Files[0];
                var imgBytes = new Byte[file.ContentLength];
                file.InputStream.Read(imgBytes, 0, file.ContentLength);
                var Base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                p.Photo = Base64String;
            }
            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Update(long id)
        {
            EFDBDatabaseEntities db = new EFDBDatabaseEntities();
            Product existingProduct = db.Products.Where(temp => temp.productId == id).FirstOrDefault();
            return View(existingProduct);
        }
        [HttpPost]
        public ActionResult Update(Product p)
        {
            EFDBDatabaseEntities db = new EFDBDatabaseEntities();
            Product existingProduct = db.Products.Where(temp => temp.productId == p.productId).FirstOrDefault();
            existingProduct.productName = p.productName;
            existingProduct.price = p.price;
            existingProduct.dateOfPurchase = p.dateOfPurchase;
            existingProduct.availabilityStatus = p.availabilityStatus;
            existingProduct.categoryId = p.categoryId;
            existingProduct.brandId = p.brandId;
            existingProduct.active = p.active;
            db.SaveChanges();
            return RedirectToAction("Index") ;
        }

        
        public ActionResult Delete(long id)
        {
            EFDBDatabaseEntities db = new EFDBDatabaseEntities();
            Product existingProduct = db.Products.Where(temp => temp.productId == id).FirstOrDefault();
            return View(existingProduct);
        }

        [HttpPost]
        public ActionResult Delete(long id, Product p)
        {
            EFDBDatabaseEntities db = new EFDBDatabaseEntities();
            Product existingProduct = db.Products.Where(temp => temp.productId == id).FirstOrDefault();
            db.Products.Remove(existingProduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}