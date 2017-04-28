using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagerMVC.Models
{
    public class Project: BaseModel
    {
        public string Name { get; set; }
        public List<User> AssignedUSers { get; set; }
        public List<Task> Tasks { get; set; }
    }
}