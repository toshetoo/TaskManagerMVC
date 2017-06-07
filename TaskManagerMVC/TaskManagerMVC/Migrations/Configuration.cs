namespace TaskManagerMVC.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Utils;

    internal sealed class Configuration : DbMigrationsConfiguration<TaskManagerMVC.TaskManagerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TaskManagerMVC.TaskManagerContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            context.Database.Delete();
            context.Database.Create();

            //USERS
            User admin = new User() { FirstName = "Admin", LastName = "Admin", Email = "admin@taskmanager.com", Username = "admin", Password = HashUtils.CreateHashCode("adminpass"), IsAdmin = true, ID = Guid.NewGuid().ToString() };
            User user = new User() { FirstName = "User", LastName = "User", Email = "user@taskmanager.com", Username = "user", Password = HashUtils.CreateHashCode("pass"), IsAdmin = false, ID = Guid.NewGuid().ToString() };
            User george = new User() { FirstName = "George", LastName = "Johnson", Email = "george@taskmanager.com", Username = "george", Password = HashUtils.CreateHashCode("pass"), IsAdmin = false, ID = Guid.NewGuid().ToString() };
            User peter = new User() { FirstName = "Peter", LastName = "Petrov", Email = "peter@taskmanager.com", Username = "peter", Password = HashUtils.CreateHashCode("pass"), IsAdmin = false, ID = Guid.NewGuid().ToString() };
            User steven = new User() { FirstName = "Steven", LastName = "Stones", Email = "steven@taskmanager.com", Username = "steven", Password = HashUtils.CreateHashCode("pass"), IsAdmin = false, ID = Guid.NewGuid().ToString() };
            User james = new User() { FirstName = "James", LastName = "Hudson", Email = "james@taskmanager.com", Username = "james", Password = HashUtils.CreateHashCode("pass"), IsAdmin = false, ID = Guid.NewGuid().ToString() };
            User hans = new User() { FirstName = "Hans", LastName = "Andersen", Email = "hans@taskmanager.com", Username = "hans", Password = HashUtils.CreateHashCode("pass"), IsAdmin = false, ID = Guid.NewGuid().ToString() };
            User victor = new User() { FirstName = "Victor", LastName = "Darnell", Email = "victor@taskmanager.com", Username = "victor", Password = HashUtils.CreateHashCode("pass"), IsAdmin = false, ID = Guid.NewGuid().ToString() };
            User minko = new User() { FirstName = "Minko", LastName = "Minkov", Email = "minko@taskmanager.com", Username = "minko", Password = HashUtils.CreateHashCode("pass"), IsAdmin = false, ID = Guid.NewGuid().ToString() };
            User totko = new User() { FirstName = "Totko", LastName = "Totkov", Email = "totko@taskmanager.com", Username = "totko", Password = HashUtils.CreateHashCode("pass"), IsAdmin = false, ID = Guid.NewGuid().ToString() };
            User dancho = new User() { FirstName = "Dancho", LastName = "Petrov", Email = "danchi@taskmanager.com", Username = "dancho", Password = HashUtils.CreateHashCode("pass"), IsAdmin = false, ID = Guid.NewGuid().ToString() };
            User gery = new User() { FirstName = "Gery", LastName = "Dobrikova", Email = "gery@taskmanager.com", Username = "gery", Password = HashUtils.CreateHashCode("pass"), IsAdmin = true, ID = Guid.NewGuid().ToString() };

            //COMMENTS
            Comment comm1 = new Comment() { ID = Guid.NewGuid().ToString(), Content = "COMMENT CONTENT", CreationDate = DateTime.Now.ToString(), CreatorID = james.ID, Title = "COMMENT TITLE" };
            Comment comm2 = new Comment() { ID = Guid.NewGuid().ToString(), Content = "COMMENT CONTENT", CreationDate = DateTime.Now.ToString(), CreatorID = hans.ID, Title = "COMMENT TITLE" };
            Comment comm3 = new Comment() { ID = Guid.NewGuid().ToString(), Content = "COMMENT CONTENT", CreationDate = DateTime.Now.ToString(), CreatorID = gery.ID, Title = "COMMENT TITLE" };
            Comment comm4 = new Comment() { ID = Guid.NewGuid().ToString(), Content = "COMMENT CONTENT", CreationDate = DateTime.Now.ToString(), CreatorID = totko.ID, Title = "COMMENT TITLE" };
            Comment comm5 = new Comment() { ID = Guid.NewGuid().ToString(), Content = "COMMENT CONTENT", CreationDate = DateTime.Now.ToString(), CreatorID = george.ID, Title = "COMMENT TITLE" };

            //PROJECTS
            Project jobsProj = new Project() { ID = Guid.NewGuid().ToString(), Name = "JobsProj"};
            jobsProj.ProjectAdminID = george.ID;
            jobsProj.AssignedUsers = new List<User>() { peter, james, victor };

            //TASKS
            Task task1 = new Task() { ID = Guid.NewGuid().ToString(), AssigneeID = peter.ID, AuthorID = gery.ID, ProjectID = jobsProj.ID, Title = "Task1", Status = TaskStatus.TODO, Content = "TASK CONTENT", CreationDate = DateTime.Now.ToString(), ImageURL = ""};
            task1.Comments = new List<Comment>() { comm1 };
            Task task2 = new Task() { ID = Guid.NewGuid().ToString(), AssigneeID = dancho.ID, AuthorID = peter.ID, ProjectID = jobsProj.ID, Title = "Task2", Status = TaskStatus.TODO, Content = "TASK CONTENT", CreationDate = DateTime.Now.ToString(), ImageURL = ""};
            task2.Comments = new List<Comment>() { comm2 };
            Task task3 = new Task() { ID = Guid.NewGuid().ToString(), AssigneeID = hans.ID, AuthorID = minko.ID, ProjectID = jobsProj.ID, Title = "Task3", Status = TaskStatus.TODO, Content = "TASK CONTENT", CreationDate = DateTime.Now.ToString(), ImageURL = "" };
            task3.Comments = new List<Comment>() { comm3 };
            Task task4 = new Task() { ID = Guid.NewGuid().ToString(), AssigneeID = totko.ID, AuthorID = james.ID, ProjectID = jobsProj.ID, Title = "Task4", Status = TaskStatus.TODO, Content = "TASK CONTENT", CreationDate = DateTime.Now.ToString(), ImageURL = "" };
            task4.Comments = new List<Comment>() { comm4 };
            Task task5 = new Task() { ID = Guid.NewGuid().ToString(), AssigneeID = gery.ID, AuthorID = victor.ID, ProjectID = jobsProj.ID, Title = "Task5", Status = TaskStatus.TODO, Content = "TASK CONTENT", CreationDate = DateTime.Now.ToString(), ImageURL = "" };
            task5.Comments = new List<Comment>() { comm5 };

            jobsProj.Tasks = new List<Task>() { task1, task2, task3, task4, task5};

            context.Users.AddOrUpdate(
              p => p.Username,
              admin, user, george, peter, steven, james, hans, victor, minko, dancho, totko, gery
            );

            context.Tasks.AddOrUpdate(t => t.Title,
                task1, task2, task3, task4, task5
             );

            context.Comments.AddOrUpdate(c => c.Title,
                comm1, comm2, comm3, comm4, comm5
             );

            context.Projects.AddOrUpdate(
                p => p.Name,
                jobsProj
            );
        }
    }
}
