namespace woordjesTestWebApiApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using woordjesTestWebApiApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<woordjesTestWebApiApp.Models.woordjesTestService>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(woordjesTestWebApiApp.Models.woordjesTestService context)
        {
            context.Woordjes.AddOrUpdate(x => x.Id,
                new Woordje() {Id = 1, WoordText = "appellare"},
                new Woordje() {Id = 1, WoordText = "curare"},
                new Woordje() {Id = 1, WoordText = "absolutus"}
            );
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
        }
    }
}
