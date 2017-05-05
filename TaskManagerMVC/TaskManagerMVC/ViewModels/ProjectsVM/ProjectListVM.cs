using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagerMVC.Models;

namespace TaskManagerMVC.ViewModels.ProjectsVM
{
    public class ProjectListVM: ListVM
    {
        public List<Project> Projects { get; set; }
    }
}