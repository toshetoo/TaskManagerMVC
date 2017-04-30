using System;
using System.Collections.Generic;
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

        public ActionResult Edit(string id)
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
            }

            model.ID = task.ID;
            model.Title = task.Title;
            model.Status = task.Status;
            model.ProjectID = task.ProjectID;
            model.CreationDate = task.CreationDate;
            model.Content = task.Content;
            model.AsigneeID = task.AsigneeID;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit()
        {
            TaskEditVM model = new TaskEditVM();
            TasksService tasksService = new TasksService();
            TryUpdateModel(model);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Models.Task task;
            if (model.ID == String.Empty)
            {
                task = new Models.Task();
            }
            else
            {
                task = tasksService.GetById(model.ID);
                if (task == null)
                {
                    return RedirectToAction("List");
                }
            }

            task.ID = model.ID;
            task.Title = model.Title;
            task.Status = model.Status;
            task.ProjectID = model.ProjectID;
            task.CreationDate = model.CreationDate;
            task.Content = model.Content;
            task.AsigneeID = model.AsigneeID;

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
    }
}