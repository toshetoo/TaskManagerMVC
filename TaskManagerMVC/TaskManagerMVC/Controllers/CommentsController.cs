using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagerMVC.Models;
using TaskManagerMVC.Services.ModelServices;
using TaskManagerMVC.ViewModels.Comments;

namespace TaskManagerMVC.Controllers
{
    public class CommentsController : Controller
    {       

        public ActionResult Edit(string id)
        {
            Comment comment = new Comment();
            CommentsService commentsService = new CommentsService();
            CommentEditVM model = new CommentEditVM();

            if (id != String.Empty)
            {
                comment = commentsService.GetById(id);
                if (comment == null)
                {
                    return new HttpStatusCodeResult(404);
                }
            }
            else
            {
                comment = new Comment();
            }

            model.ID = comment.ID;
            model.Title = comment.Title;
            model.Content = comment.Content;
            model.CreatorID = comment.CreatorID;
            model.CreationDate = comment.CreationDate;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit()
        {
            CommentEditVM model = new CommentEditVM();
            CommentsService commentsService = new CommentsService();
            TryUpdateModel(model);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Comment comment;
            if (model.ID == String.Empty)
            {
                comment = new Comment();
            }
            else
            {
                comment = commentsService.GetById(model.ID);
                if (comment == null)
                {
                    return new HttpStatusCodeResult(404);
                }
            }

            comment.ID = model.ID;
            comment.Title = model.Title;
            comment.Content = model.Content;
            comment.CreatorID = model.CreatorID;
            comment.CreationDate = model.CreationDate;

            commentsService.Update(comment);

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