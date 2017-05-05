using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagerMVC.ViewModels.Comments
{
    public class CommentEditVM
    {
        public string Content { get; set; }
        public string CreationDate { get; set; }
        public string CreatorID { get; set; }
        public string ID { get; set; }
        public string Title { get; set; }
    }
}