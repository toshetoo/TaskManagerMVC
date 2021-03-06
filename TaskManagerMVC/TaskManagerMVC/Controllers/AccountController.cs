﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagerMVC.Filters;
using TaskManagerMVC.Models;
using TaskManagerMVC.Services.ModelServices;
using TaskManagerMVC.Utils;
using TaskManagerMVC.ViewModels.AccountVM;

namespace TaskManagerMVC.Controllers
{
    public class AccountController : Controller
    {
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

            u.ID = Guid.NewGuid().ToString();
            u.Username = model.Username;
            u.Password = model.Password;
            u.FirstName = model.FirstName;
            u.LastName = model.LastName;
            u.Email = model.Email;

            usersService.Insert(u);
            TaskManagerMVC.Services.EmailService.SendRegistrationEmail(u);
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
            u.Password = HashUtils.CreateHashCode(model.Password);
            u.FirstName = model.FirstName;
            u.LastName = model.LastName;
            u.Email = model.Email;

            usersService.Update(u);
            return RedirectToAction("Login");
        }

        public ActionResult ResetPassword()
        {    
            return View();
        }

        [HttpPost]
        public ActionResult ResetPassword(string email)
        {
            UsersService service = new UsersService();
            User user = service.GetAll().FirstOrDefault(u => u.Email == email);
            user.Password = Guid.NewGuid().ToString();

            service.Update(user);
            ViewBag.Message = "Email with instructions has been sent!";

            TaskManagerMVC.Services.EmailService.SendPasswordResetEmail(user);

            return View();
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

            TaskManagerMVC.Services.AuthenticatonService.AuthenticateUser(model.Username, model.Password);
            if (TaskManagerMVC.Services.AuthenticatonService.LoggedUser != null)
            {
                if (!String.IsNullOrEmpty(model.RedirectUrl))
                    return Redirect(model.RedirectUrl);

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            TaskManagerMVC.Services.AuthenticatonService.Logout();

            return RedirectToAction("Login");
        }
    }
}