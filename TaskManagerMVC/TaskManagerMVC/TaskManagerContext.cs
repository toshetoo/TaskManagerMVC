using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TaskManagerMVC.Migrations;
using TaskManagerMVC.Models;

namespace TaskManagerMVC
{
    public class TaskManagerContext: DbContext
    {
        public TaskManagerContext() : base("TaskManagerDB")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TaskManagerContext, Configuration>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }

        public DbSet<Comment> Comments { get; set; }
    }
}