using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagerMVC.Models;
using TaskManagerMVC.Services;
using TaskManagerMVC.Services.ModelServices;
using TaskManagerMVC.ViewModels.AccountVM;

namespace TaskManagerMVC.Controllers
{
    public class AccountsController : Controller
    {
        [ValidateAntiForgeryToken]
        public ActionResult Register()
        {
            AccountRegisterVM model = new AccountRegisterVM();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(AccountRegisterVM model)
        {

            model.Password = Guid.NewGuid().ToString();

            User u = new User();
            UsersService usersService = new UsersService();

            u.Username = model.Username;
            u.Password = model.Password;
            u.FirstName = model.FirstName;
            u.LastName = model.LastName;
            u.Email = model.Email;

            usersService.Insert(u);
            EmailService.SendRegistrationEmail(u);
            return RedirectToAction("Login");
        }
        public ActionResult Verify(string guid)
        {
            AccountRegisterVM model = new AccountRegisterVM();

            UsersService usersService = new UsersService();
            User u = new User();
            u = usersService.GetByGuid(guid);

            model.ID = u.ID;
            model.FirstName = u.FirstName;
            model.LastName = u.LastName;
            model.Username = u.Username;
            model.Email = u.Email;

            return View(model);
        }

        [HttpPost]
        public ActionResult Verify()
        {
            AccountRegisterVM model = new AccountRegisterVM();
            TryUpdateModel(model);

            User u = new User();
            UsersService usersService = new UsersService();

            u.ID = model.ID;
            u.Username = model.Username;
            u.Password = model.Password;
            u.FirstName = model.FirstName;
            u.LastName = model.LastName;
            u.Email = model.Email;

            usersService.Update(u);
            return RedirectToAction("Login");
        }
        public ActionResult Login(string RedirectUrl)
        {
            AccountLoginVM model = new AccountLoginVM();
            model.RedirectUrl = RedirectUrl;

            return View(model);
        }
        [HttpPost]
        public ActionResult Login()
        {
            AccountLoginVM model = new AccountLoginVM();
            TryUpdateModel(model);

            AuthenticatonService.AuthenticateUser(model.Username, model.Password);
            if (AuthenticatonService.LoggedUser != null)
            {
                if (!String.IsNullOrEmpty(model.RedirectUrl))
                    return Redirect(model.RedirectUrl);

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            AuthenticatonService.Logout();

            return RedirectToAction("Login");
        }
    }
}