using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Day5ModelsDemo.Models;

namespace Day5ModelsDemo.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult Index()
        {
            List<Product> product = new List<Product>()
            {
                new Product{ProductId=1,ProductName="Scooty",ProductRate=60000},
                new Product{ProductId=2,ProductName="Cars",ProductRate=90000},
                new Product{ProductId=3,ProductName="Bikes",ProductRate=70000}
            };
            ViewBag.Product = product;
            return View();
        }
        public ActionResult Details(int id)
        {
            List<Product> product = new List<Product>()
            {
                new Product{ProductId=1,ProductName="Scooty",ProductRate=60000},
                new Product{ProductId=2,ProductName="Cars",ProductRate=90000},
                new Product{ProductId=3,ProductName="Bikes",ProductRate=70000}
            };
            Product matchingProd=null;
            foreach(var item in product)
            {
                if (item.ProductId == id)
                {
                    matchingProd = item;
                }
            }
            ViewBag.MatchingProduct=matchingProd;
            return View();

        }
    }
}