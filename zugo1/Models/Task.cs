using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace zugo1.Models
{
    public class Task
    {
        public int? id { get; set; }
        public string taskDescription { get; set; }
        public string taskDate { get; set; }
    }
}