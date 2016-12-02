using FastLearn.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FastLearn.com.Models
{
    public class Category
    {   [Key]
        public int ID { get; set; }
        public string name { get; set; }
        public virtual ICollection<Course>Courses { get; set; }
    }
}