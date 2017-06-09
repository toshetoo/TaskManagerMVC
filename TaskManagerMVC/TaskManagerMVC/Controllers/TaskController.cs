﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagerMVC.Services.ModelServices;
using TaskManagerMVC.ViewModels.TaskVM;

namespace TaskManagerMVC.Controllers
{
    public class TaskController : BaseController
    {
        public ActionResult List()
        {
            TaskListVM model = new TaskListVM();
            TryUpdateModel(model);

            model.Tasks = new TasksService().GetAll();

            if (!string.IsNullOrEmpty(model.Search))
            {
                model.Tasks = model.Tasks.Where(u => u.Title.ToLower().Contains(model.Search)).ToList();
            }

            switch (model.SortOrder)
            {
                case "title_asc": model.Tasks = model.Tasks.OrderBy(u => u.Title).ToList(); break;
                case "title_desc": model.Tasks = model.Tasks.OrderByDescending(u => u.Title).ToList(); break;
            }

            return View(model);
        }

        public ActionResult Edit(string id=null)
        {
            Models.Task task = new Models.Task();
            TasksService tasksService = new TasksService();
            TaskEditVM model = new TaskEditVM();

            if (id != null)
            {
                task = tasksService.GetById(id);
                if (task == null)
                {
                    return RedirectToAction("List");
                }
            }
            else
            {
                task = new Models.Task();
                model.ID = Guid.NewGuid().ToString();
            }

            model.ID = task.ID;
            model.Title = task.Title;
            model.Status = task.Status;
            model.ProjectID = task.ProjectID;
            model.CreationDate = task.CreationDate;
            model.Content = task.Content;
            model.ImageURL = task.ImageURL;
            model.AsigneeID = task.AssigneeID;

            model.Users = GetUsers();
            model.Projects = GetProjects();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit()
        {
            TaskEditVM model = new TaskEditVM();
            TasksService tasksService = new TasksService();
            
            TryUpdateModel(model);
            bool toInsert = model.ID == null;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Models.Task task;
            if (model.ID == null)
            {
                task = new Models.Task();
                model.ID = Guid.NewGuid().ToString();
                model.CreationDate = DateTime.Now.ToString();
            }
            else
            {
                task = tasksService.GetById(model.ID);
                if (task == null)
                {
                    return RedirectToAction("List");
                }
            }

            //if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
            //{
            //    var imageExtension = Path.GetExtension(model.ImageUpload.FileName);

            //    if (String.IsNullOrEmpty(imageExtension) || !imageExtension.Equals(".jpg", StringComparison.OrdinalIgnoreCase))
            //    {
            //        ModelState.AddModelError(string.Empty, "Wrong image format.");
            //    }
            //    else
            //    {
            //        string filePath = Server.MapPath("~/Uploads/");
            //        model.ImageURL = model.ImageUpload.FileName;
            //        model.ImageUpload.SaveAs(filePath + model.ImageURL);
            //    }
            //}
            //else
            //{
            //    model.ImageURL = "default.jpg";
            //}

            task.ID = model.ID;
            task.Title = model.Title;
            task.Status = model.Status;
            task.ProjectID = model.ProjectID;
            task.CreationDate = model.CreationDate;
            task.Content = model.Content;
            task.AssigneeID = model.AsigneeID;
            task.ImageURL = model.ImageURL;

            if(toInsert)
                tasksService.Insert(task);
            else
                tasksService.Update(task);

            return RedirectToAction("List");
        }

        public ActionResult Delete(string id)
        {
            TasksService tasksService = new TasksService();

            if (id != String.Empty)
            {
                tasksService.Delete(id);
            }
            return RedirectToAction("List");
        }

        private IEnumerable<SelectListItem> GetUsers()
        {
            var users = new UsersService().GetAll()
                .Select(h => new SelectListItem
                {
                    Value = h.ID.ToString(),
                    Text = h.FirstName + " " + h.LastName
                });

            return new SelectList(users, "Value", "Text");
        }

        private IEnumerable<SelectListItem> GetProjects()
        {
            var projects = new ProjectsService().GetAll()
                .Select(p => new SelectListItem
                {
                    Value = p.ID.ToString(),
                    Text = p.Name
                });

            return new SelectList(projects, "Value", "Text");
        }

    }
}