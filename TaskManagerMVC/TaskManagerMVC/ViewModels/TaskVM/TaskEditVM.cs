using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagerMVC.Models;

namespace TaskManagerMVC.ViewModels.TaskVM
{
    public class TaskEditVM
    {        
        public string ID { get; set; }
        [Display(Name = "Project")]
        public string ProjectID { get; set; }
        [Display(Name = "Asignee")]
        public string AsigneeID { get; set; }

        [Required(ErrorMessage = "Please enter a title!")]
        [RegularExpression(@"^([A-z -]+)$", ErrorMessage = "Title is not valid!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Title shoudl contain between 3 and 50 characters")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter some content!")]
        public string Content { get; set; }
        public TaskStatus Status { get; set; }

        [Display(Name = "Creation date")]
        public string CreationDate { get; set; }
        public string ImageURL { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }

        public IEnumerable<SelectListItem> Users { get; set; }

        public IEnumerable<SelectListItem> Projects { get; set; }
    }
}