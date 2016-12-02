using FastLearn.com.Models;
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
        [Required]
        public int ID { get; set; }
        [Required]
        
        public string Title { get; set; }
        [Required]
        public string CourseImage { get; set; }
        [Required]
        public string CourseDescribtion { get; set; }
        [Required]
        public string CategoryID { get; set; }
        [Required]
        public Category Category { get; set;}
        [Required]
        public float price { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<CourseFile> CourseFiles { get; set; }
        public string InstructorID { get; set; }
    }
}