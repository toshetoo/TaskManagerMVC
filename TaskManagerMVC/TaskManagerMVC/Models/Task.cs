using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagerMVC.Models
{
    public class Task: BaseModel
    {
        public string ProjectID { get; set; }
        public string AuthorID { get; set; }
        public string AssigneeID { get; set; }
        public string Title { get; set; }
        public TaskStatus Status { get; set; }
        public string Content { get; set; }
        public string CreationDate { get; set; }

        public string ImageURL { get; set; }

        public virtual List<Comment> Comments { get; set; }
        public virtual Project Project { get; set; }
        public virtual User Author { get; set; }
        public virtual User Assignee { get; set; }
    }

    public enum TaskStatus
    {
        TODO, INPROGRESS, DONE
    }
}