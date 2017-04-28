namespace TaskManagerMVC.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TaskManagerMVC.Data.TaskManagerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TaskManagerMVC.Data.TaskManagerContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Users.AddOrUpdate(
              p => p.Username,
              new Models.User { Username = "Andrew Peters" },
              new Models.User { Username = "Brice Lambson" },
              new Models.User { Username = "Rowan Miller" }
            );

        }
    }
}
