namespace Day6EFDBDemo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Day6EFDBDemo.Models.CompanyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Day6EFDBDemo.Models.CompanyDbContext";
        }

        protected override void Seed(Day6EFDBDemo.Models.CompanyDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Brands.AddOrUpdate(new Models.Brand() { brandId = 1, brandName = "Apple" }, new Models.Brand() { brandId = 2, brandName = "Samsung" });
            context.Categories.AddOrUpdate(new Models.Category() { categoryId = 1, categoryName = "Mobile" }, new Models.Category() { categoryId= 2, categoryName = "Home Application" });


        }
    }
}
