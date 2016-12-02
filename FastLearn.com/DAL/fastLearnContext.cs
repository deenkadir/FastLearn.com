using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using FastLearn.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FastLearn.com.DAL
{
    public class fastLearnContext : DbContext
    {
        public fastLearnContext():base("fastLearnContex")
        {

        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseFile> CourseFiles { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<FastLearn.com.Models.Category> Categories { get; set; }
    }
}