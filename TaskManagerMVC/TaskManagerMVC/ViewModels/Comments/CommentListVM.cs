using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagerMVC.Models;

namespace TaskManagerMVC.ViewModels.Comments
{
    public class CommentListVM: ListVM
    {
        public List<Comment> Comments { get; set; }
    }
}