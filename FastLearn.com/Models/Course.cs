using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FastLearn.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string CourseImage { get; set; }
        public string CourseDescribtion { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<CourseFile> CourseFiles { get; set; }
    }
}