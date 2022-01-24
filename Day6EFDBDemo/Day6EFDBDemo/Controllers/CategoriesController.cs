﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Day6EFDBDemo.Models;

namespace Day6EFDBDemo.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {
            EFDBDatabaseEntities db = new EFDBDatabaseEntities();
            List<Category> categories = db.Categories.ToList();
            return View(categories);
        }
    }
}