using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagerMVC.Models
{
    public class Project: BaseModel
    {
        public string ProjectAdminID { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public virtual List<User> AssignedUsers { get; set; }
        public virtual List<Task> Tasks { get; set; }

        public virtual User ProjectAdmin { get; set; }
    }
}