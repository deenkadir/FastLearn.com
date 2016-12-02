using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FastLearn.Models;
using FastLearn.com.Models;
using Microsoft.AspNet.Identity;

namespace FastLearn.com.Controllers
{
    public class CourseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Course
       // [Authorize]
      //  [Authorize(Roles ="Instructor")]
      //  [Authorize(Roles ="Admin")]
        public ActionResult Index()
        {
            var courses = db.Courses.Include(c => c.Category);
            
            return View(courses.ToList());
        }
        [Authorize(Roles = "Instructor")]
       // [Authorize(Roles = "Admin")]
        // GET: Course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }
        [Authorize(Roles = "Instructor")]
     //   [Authorize(Roles = "Admin")]
        // GET: Course/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "name");
            return View();
        }

        // POST: Course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Instructor")]
      //  [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,CourseImage,CourseDescribtion,CategoryID,InstructorID")] Course course)
        {
            if (ModelState.IsValid)
            {
                course = new Course {Title = course.Title,CourseImage = course.CourseImage,CourseDescribtion = course.CourseDescribtion,InstructorID = User.Identity.GetUserId(),CategoryID = course.CategoryID };
                // db.Courses.Add(course);
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           // var user = UserManager.FindById(User.Identity.Name);
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "name", course.CategoryID);
            return View(course);
        }

        // GET: Course/Edit/5
        [Authorize(Roles = "Instructor")]
       // [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "name", course.CategoryID);
            return View(course);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Instructor")]
       // [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "ID,Title,CourseImage,CourseDescribtion,CategoryID,InstructorID")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "name", course.CategoryID);
            return View(course);
        }

        // GET: Course/Delete/5
        [Authorize(Roles = "Instructor")]
       // [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
