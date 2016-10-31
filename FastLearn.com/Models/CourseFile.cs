using System.ComponentModel.DataAnnotations;

namespace FastLearn.Models
{
    public class CourseFile
    {
        [Key]
        public int ID { get; set; }
        public int CourseID { get; set; }
        public string File { get; set; }
        public Course Course { get; set; }
    }
}