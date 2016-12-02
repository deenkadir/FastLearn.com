namespace FastLearn.com.Migrations
{
    using FastLearn.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.Ajax.Utilities;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Microsoft.AspNet.Identity;

    internal sealed class Configuration : DbMigrationsConfiguration<FastLearn.com.Models.ApplicationDbContext>
    {
        public Configuration()
        {
           
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "FastLearn.com.Models.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {//getting user storage
            var userStore = new UserStore<ApplicationUser>(context);
            //setting to the userManager to access direct access
            var userManager = new UserManager<ApplicationUser>(userStore);
            context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "Instructor" });
            if (!context.Users.Any(u=>u.UserName == "Admin"))
            {
                // string passWord = "PassW0rd!";
                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "Instructor" });
                var user = new ApplicationUser {UserName = "Admin", Email="admin@Fastlearn.com"};
                userManager.Create(user, "PassW0rd!");
                context.Roles.AddOrUpdate(r=>r.Name, new IdentityRole {Name="Admin" });
                context.SaveChanges();
                userManager.AddToRole(user.Id, user.UserName);
            }
            Course course = new Course { ID = 1, Title = "Test Data", CategoryID = "1", CourseDescribtion = "test Description", InstructorID = "abdul@gmail.com", CourseImage = "fjldsfs", price = 3 };
            context.Courses.AddOrUpdate(r=>r.ID);
            context.SaveChanges();
            //DbSet<Course>.AddOrUpdate()
            //  This method will be called after migrating to the latest version.

            // You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
