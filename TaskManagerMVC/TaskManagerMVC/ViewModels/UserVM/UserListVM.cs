using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagerMVC.Models;

namespace TaskManagerMVC.ViewModels.UserVM
{
    public class UserListVM:ListVM
    {
        public List<User> Users { get; set; }
    }
}