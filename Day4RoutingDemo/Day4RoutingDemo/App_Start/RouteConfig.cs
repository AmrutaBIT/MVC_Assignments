using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Day4RoutingDemo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Using this only one of the routes work so we modify it as below
            //routes.MapRoute(
            //    name: "Product",
            //    url: "{controller}/{action}/{prodName}",
            //    defaults: new { }
            //    );

            //Method1
            //    routes.MapRoute(
            //    name: "Products",
            //    url: "Product/getprodid/{prodName}",
            //    defaults: new { controller = "Product", action = "GetProdId" }
            //    );

            //Method2 using Contraints
            routes.MapRoute(
                name: "Products",
                url: "{controller}/{action}/{prodName}",
                defaults: new { },
                constraints: new { prodName = @"^[A-Za-z]*$" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
