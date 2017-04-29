using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagerMVC.Models;
using TaskManagerMVC.Services.ModelServices;

namespace TaskManagerMVC.Services
{
    public static class AuthenticatonService
    {
        public static User LoggedUser { get; set; }

        public static void AuthenticateUser(string username, string password)
        {
            LoggedUser = new UsersService().GetByUsernameAndPassword(username, password);
        }

        public static void Logout()
        {
            LoggedUser = null;
        }
    }
}