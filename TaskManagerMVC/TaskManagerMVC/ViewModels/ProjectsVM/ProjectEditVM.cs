using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagerMVC.Models;

namespace TaskManagerMVC.ViewModels.ProjectsVM
{
    public class ProjectEditVM
    {
        public List<User> AssignedUSers { get; internal set; }
        public string ID { get; internal set; }
        public string Name { get; internal set; }
        public string ProjectAdminID { get; internal set; }
        public string ImageURL { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }
        public List<Task> Tasks { get; internal set; }
    }
}