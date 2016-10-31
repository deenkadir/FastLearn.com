using System.ComponentModel.DataAnnotations;

namespace FastLearn.Models
{
    public class Enrollment
    {   
        [Key]
        public int ID { get; set; }
        public string StudentID { get; set; }
        public int CourseID { get; set; }
        public float price { get; set; }
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}