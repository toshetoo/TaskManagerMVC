using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagerMVC.Models;
using TaskManagerMVC.Services.ModelServices;
using TaskManagerMVC.ViewModels.ProjectsVM;

namespace TaskManagerMVC.Controllers
{
    public class ProjectsController : Controller
    {
        public ActionResult List()
        {
            ProjectListVM model = new ProjectListVM();
            TryUpdateModel(model);

            model.Projects = new ProjectsService().GetAll();

            if (!string.IsNullOrEmpty(model.Search))
            {
                model.Projects = model.Projects.Where(u => u.Name.ToLower().Contains(model.Search)).ToList();
            }

            switch (model.SortOrder)
            {
                case "name_asc": model.Projects = model.Projects.OrderBy(u => u.Name).ToList(); break;
                case "name_desc": model.Projects = model.Projects.OrderByDescending(u => u.Name).ToList(); break;
            }

            return View(model);
        }

        public ActionResult Details(string id)
        {
            Project project = new Project();
            ProjectsService projectsService = new ProjectsService();

            if (id != null)
            {
                project = projectsService.GetById(id);
                if (project == null)
                {
                    return RedirectToAction("List");
                }
            }
            else
            {
                return RedirectToAction("List");
            }

            return View(project);
        }

        public ActionResult Edit(string id)
        {
            Project project = new Project();
            ProjectsService projectsService = new ProjectsService();
            ProjectEditVM model = new ProjectEditVM();

            if (id != null)
            {
                project = projectsService.GetById(id);
                if (project == null)
                {
                    return RedirectToAction("List");
                }
            }
            else
            {
                project = new Project();
            }

            model.ID = project.ID;
            model.Name = project.Name;
            model.AssignedUSers = project.AssignedUsers;
            model.ProjectAdminID = project.ProjectAdminID;
            model.Tasks = project.Tasks;
            model.ImageURL = project.ImageURL;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProjectEditVM model)
        {
            ProjectEditVM mymodel = new ProjectEditVM();
            TryUpdateModel(mymodel);
            ProjectsService projectsService = new ProjectsService();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Project project;
            if (model.ID == String.Empty)
            {
                project = new Project();
            }
            else
            {
                project = projectsService.GetById(model.ID);
                if (project == null)
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

            project.ID = model.ID;
            project.Name = model.Name;
            project.ProjectAdminID = model.ProjectAdminID;
            project.AssignedUsers = model.AssignedUSers;
            project.Tasks = model.Tasks;
            project.ImageURL = model.ImageURL;

            projectsService.Update(project);

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