using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;
using TaskManagerMVC.Models;
using TaskManagerMVC.Services.ModelServices;
using TaskManagerMVC.ViewModels.UserVM;

namespace TaskManagerMVC.Controllers
{
    public class UserController : BaseController
    {
        public ActionResult List()
        {
            UserListVM model = new UserListVM();
            TryUpdateModel(model);

            model.Users = new UsersService().GetAll();

            if (!string.IsNullOrEmpty(model.Search))
            {
                model.Users = model.Users.Where(u => u.FirstName.ToLower().Contains(model.Search) || u.LastName.ToLower().Contains(model.Search) || u.Username.ToLower().Contains(model.Search)).ToList();
            }

            switch (model.SortOrder)
            {
                case "username_asc": model.Users = model.Users.OrderBy(u => u.Username).ToList(); break;
                case "username_desc": model.Users = model.Users.OrderByDescending(u => u.Username).ToList(); break;
                case "firstname_asc": model.Users = model.Users.OrderBy(u => u.FirstName).ToList(); break;
                case "firstname_desc": model.Users = model.Users.OrderByDescending(u => u.FirstName).ToList(); break;
                case "lastname_asc": model.Users = model.Users.OrderBy(u => u.LastName).ToList(); break;
                case "lastname_desc": model.Users = model.Users.OrderByDescending(u => u.LastName).ToList(); break;
            }

            return View(model);
        }

        public ActionResult Edit(string id = null)
        {
            User user = new User();
            UsersService userService = new UsersService();
            UserEditVM model = new UserEditVM();

            if (id != null)
            {
                user = userService.GetById(id);
                if (user == null)
                {
                    return RedirectToAction("List");
                }
            }
            else
            {
                user = new User();
            }

            model.ID = user.ID;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.Username = user.Username;
            model.Password = user.Password;
            model.Email = user.Email;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit()
        {
            UserEditVM model = new UserEditVM();
            UsersService usersService = new UsersService();
            TryUpdateModel(model);
            bool toInsert = model.ID == null;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            User user;
            if (model.ID == null)
            {
                user = new User();
                model.ID = Guid.NewGuid().ToString();
            }
            else
            {
                user = usersService.GetById(model.ID);
                if (user == null)
                {
                    return RedirectToAction("List");
                }
            }

            if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
            {
                var imageExtension = Path.GetExtension(model.ImageUpload.FileName);

                if (String.IsNullOrEmpty(imageExtension) || !imageExtension.Equals(".jpg", StringComparison.OrdinalIgnoreCase))
                {
                    ModelState.AddModelError(string.Empty, "Wrong image format.");
                }
                else
                {
                    string filePath = Server.MapPath("~/Uploads/");
                    model.ImageURL = model.ImageUpload.FileName;
                    model.ImageUpload.SaveAs(filePath + model.ImageURL);
                }
            }
            else
            {
                model.ImageURL = "default.jpg";
            }

            user.ID = model.ID;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Password = model.Password;
            user.Username = model.Username;
            user.Email = model.Email;
            user.ImageUrl = model.ImageURL;

            if(toInsert)
                usersService.Insert(user);
            else
                usersService.Update(user);

            return RedirectToAction("List");
        }

        public ActionResult Delete(string id)
        {
            UsersService usersService = new UsersService();

            if (id != String.Empty)
            {
                usersService.Delete(id);
            }
            return RedirectToAction("List");
        }
    }
}