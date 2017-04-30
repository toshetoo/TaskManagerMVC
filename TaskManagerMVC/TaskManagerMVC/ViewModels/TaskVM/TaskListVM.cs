using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagerMVC.ViewModels.TaskVM
{
    public class TaskListVM:ListVM
    {
        public List<Models.Task> Tasks { get; set; }
    }
}