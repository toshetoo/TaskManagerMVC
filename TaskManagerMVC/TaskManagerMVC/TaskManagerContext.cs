using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TaskManagerMVC.Models;

namespace TaskManagerMVC
{
    public class TaskManagerContext: DbContext
    {
        public TaskManagerContext() : base("TaskManagerDB")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
    }
}