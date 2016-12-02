using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FastLearn.com.Models
{
    public class Instructor
    {
        [Key]
        [Required]
        public string ID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string image { get; set; }
        public string Biography { get; set; }
        public DateTime JoinedDate { get; set; }
    }
}