using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagerMVC.Models;
using TaskManagerMVC.Utils;

namespace TaskManagerMVC.Services.ModelServices
{
    public class UsersService:BaseService<User>
    {
        public UsersService(): base()
        {

        }

        public User GetByUsernameAndPassword(string username, string password)
        {
            return this.GetAll().FirstOrDefault(u => u.Username == username && HashUtils.VerifyPassword(password, u.Password));
        }
    }
}