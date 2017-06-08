using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagerMVC.Models;

namespace TaskManagerMVC.ViewModels.ProjectsVM
{
    public class ProjectEditVM
    {
        public List<User> AssignedUSers { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public string ProjectAdminID { get; set; }
        public string ImageURL { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }
        public List<Task> Tasks { get; set; }

        public IEnumerable<SelectListItem> Users { get; set; }
    }
}