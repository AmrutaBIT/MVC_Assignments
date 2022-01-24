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
        public ActionResult Index(string search= "")
        {
            EFDBDatabaseEntities db= new EFDBDatabaseEntities();
            //List<Product> products = db.Products.Where(temp =>temp.categoryId==1 && temp.price >10000).ToList();
            List<Product> products = db.Products.Where(temp => temp.productName.Contains(search)).ToList();
            ViewBag.search = search;
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