using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagerMVC.Models
{
    public class Comment: BaseModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string CreatorID { get; set; }
        public string CreationDate { get; set; }
    }
}