namespace DAL.Migrations
{
    using Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.ShoppingListContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DAL.ShoppingListContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Products.AddOrUpdate(new Product { Name = "Pepsi", Type = "Drink" });
            context.Products.AddOrUpdate(new Product { Name = "Coca-cola", Type = "Drink" });
            context.Products.AddOrUpdate(new Product { Name = "Pringles", Type = "Food" });
            context.Products.AddOrUpdate(new Product { Name = "Mango", Type = "Fruit" });
        }
    }
}
