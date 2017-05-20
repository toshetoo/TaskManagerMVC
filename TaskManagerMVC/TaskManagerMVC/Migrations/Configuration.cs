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

            var admin = new User() { FirstName = "Admin", LastName = "Admin", Email = "admin@taskmanager.com", Username = "admin", Password = HashUtils.CreateHashCode("adminpass"), IsAdmin = true, ID = Guid.NewGuid().ToString() };
            var user = new User() { FirstName = "User", LastName = "User", Email = "user@taskmanager.com", Username = "user", Password = HashUtils.CreateHashCode("pass"), IsAdmin = false, ID = Guid.NewGuid().ToString() };
            var george = new User() { FirstName = "George", LastName = "Johnson", Email = "george@taskmanager.com", Username = "george", Password = HashUtils.CreateHashCode("pass"), IsAdmin = false, ID = Guid.NewGuid().ToString() };
            var peter = new User() { FirstName = "Peter", LastName = "Petrov", Email = "peter@taskmanager.com", Username = "peter", Password = HashUtils.CreateHashCode("pass"), IsAdmin = false, ID = Guid.NewGuid().ToString() };
            var steven = new User() { FirstName = "Steven", LastName = "Stones", Email = "steven@taskmanager.com", Username = "steven", Password = HashUtils.CreateHashCode("pass"), IsAdmin = false, ID = Guid.NewGuid().ToString() };
            var james = new User() { FirstName = "James", LastName = "Hudson", Email = "james@taskmanager.com", Username = "james", Password = HashUtils.CreateHashCode("pass"), IsAdmin = false, ID = Guid.NewGuid().ToString() };
            var hans = new User() { FirstName = "Hans", LastName = "Andersen", Email = "hans@taskmanager.com", Username = "hans", Password = HashUtils.CreateHashCode("pass"), IsAdmin = false, ID = Guid.NewGuid().ToString() };
            var victor = new User() { FirstName = "Victor", LastName = "Darnell", Email = "victor@taskmanager.com", Username = "victor", Password = HashUtils.CreateHashCode("pass"), IsAdmin = false, ID = Guid.NewGuid().ToString() };
            var minko = new User() { FirstName = "Minko", LastName = "Minkov", Email = "minko@taskmanager.com", Username = "minko", Password = HashUtils.CreateHashCode("pass"), IsAdmin = false, ID = Guid.NewGuid().ToString() };
            var totko = new User() { FirstName = "Totko", LastName = "Totkov", Email = "totko@taskmanager.com", Username = "totko", Password = HashUtils.CreateHashCode("pass"), IsAdmin = false, ID = Guid.NewGuid().ToString() };
            var dancho = new User() { FirstName = "Dancho", LastName = "Petrov", Email = "danchi@taskmanager.com", Username = "dancho", Password = HashUtils.CreateHashCode("pass"), IsAdmin = false, ID = Guid.NewGuid().ToString() };

            context.Users.AddOrUpdate(
              p => p.Username,
              admin, user, george, peter, steven, james, hans, victor, minko, dancho, totko
            );


            context.Projects.AddOrUpdate(
                p => p.Name,
                new Project() { ID = Guid.NewGuid().ToString(), Name = "JobsProj", ProjectAdminID = george.ID, AssignedUsers = { peter, james, victor }, Tasks = { } }
            );
        }
    }
}
