using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day5ModelsDemo.Models
{
    public class CustomBinder:IModelBinder
    {
        public object BindModel(ControllerContext controllerContext ,ModelBindingContext bindingContext)
        {
            int StudentId = Convert.ToInt32(controllerContext.HttpContext.Request.Form["StudentId"]);
            int StudentName = Convert.ToInt32(controllerContext.HttpContext.Request.Form["StudentName"]);
            int Dno = Convert.ToInt32(controllerContext.HttpContext.Request.Form["Dno"]);
            int Street = Convert.ToInt32(controllerContext.HttpContext.Request.Form["Street"]);
            int Landmark = Convert.ToInt32(controllerContext.HttpContext.Request.Form["Landmark"]);
            int City = Convert.ToInt32(controllerContext.HttpContext.Request.Form["City"]);
            return new { StudentId = StudentId, StudentName = StudentName, Address = Dno + "," + Street + "," + Landmark + "," + City };
        }
    }
}