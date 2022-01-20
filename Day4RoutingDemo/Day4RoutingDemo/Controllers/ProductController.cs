using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day4RoutingDemo.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        public ActionResult Index()
        {
            return View();
        }

        [Route("Product/Details/{id:int}")]
        public ActionResult Details(int? id)
        {
            var product = new[] {
            new {productid=1, productname="Iphone",cost=80000},
            new { productid = 2, productname = "VivoY12", cost = 80000 },
            new { productid = 3, productname = "SamsungA4", cost = 80000 },
        };
            string productname = "";
            if (id == null)
            {
                return Content("Please pass a product id");
            }
            else
            {
                foreach (var pro in product)
                {
                    if (pro.productid == id)
                    {
                        productname = pro.productname;
                    }

                }
                return Content(productname);
            }
        
        }
        [Route("Product/GetProdId/{prodName:string}")]
        public ActionResult GetProdId(string prodName)
        {
            var product = new[] {
            new {productid=1, productname="Iphone",cost=80000},
            new { productid = 2, productname = "VivoY12", cost = 80000 },
            new { productid = 3, productname = "SamsungA4", cost = 80000 },
        };
            int productid = 0;
            if (prodName == null)
            {
                return Content("Please enter a product Name");
            }
            else
            {
                foreach (var item in product)
                {
                    if (item.productname == prodName)
                    {
                        productid = item.productid;
                    }
                }
                return Content(productid.ToString());
            }

        }

    }
}