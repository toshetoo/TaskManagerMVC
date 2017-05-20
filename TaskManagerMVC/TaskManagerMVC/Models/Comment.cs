﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagerMVC.Models
{
    public class Comment: BaseModel
    {
        public string TaskID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string CreatorID { get; set; }
        public string CreationDate { get; set; }

        public virtual User Creator { get; set; }
        public virtual Task Task { get; set; }
    }
}