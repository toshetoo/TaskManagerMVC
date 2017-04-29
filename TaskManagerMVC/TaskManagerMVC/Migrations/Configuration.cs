namespace TaskManagerMVC.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Utils;

    internal sealed class Configuration : DbMigrationsConfiguration<TaskManagerMVC.TaskManagerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TaskManagerMVC.TaskManagerContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            
            //context.Users.AddOrUpdate(
            //  p => p.Username,
            //  new User { FirstName="Admin", LastName="Admin", Email="admin@admin.com", Username = "admin", Password= HashUtils.CreateHashCode("adminpass")}
            //);            
        }
    }
}
