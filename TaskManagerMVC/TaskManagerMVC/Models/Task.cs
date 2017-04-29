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
        public string AsigneeID { get; set; }
        public string Title { get; set; }
        public TaskStatus Status { get; set; }
        public string Content { get; set; }
        public string CreationDate { get; set; }
    }

    public enum TaskStatus
    {
        TODO, INPROGRESS, DONE
    }
}