using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FastLearn.com.Models;
using FastLearn.com.DAL;
using FastLearn.Models;
using System.Threading.Tasks;

namespace FastLearn.com.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult test()
        {

            return View();
        }
        [HttpPost]
        public  ActionResult test(Course model)
        {
            if (ModelState.IsValid)
            {
                var db = new ApplicationDbContext();
                var course = new Course
                {
                    ID = 1,
                    CourseDescribtion = model.CourseDescribtion,
                    CourseFiles = model.CourseFiles
                ,
                    CourseImage = model.CourseImage,
                    Genre = model.Genre,
                    Title = model.Title
                };
                db.Courses.Add(course);
                db.SaveChanges();
               
            }
            return View("Index");
        }
    }
}