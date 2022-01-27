using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Day6EFDBDemo.Migrations;

namespace Day6EFDBDemo.Models
{
    public class CompanyDbContext:DbContext
    {
        public CompanyDbContext() : base("MyConnString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CompanyDbContext, Configuration>());
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }    
    }
}