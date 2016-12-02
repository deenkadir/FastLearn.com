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
    public class CourseFilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CourseFiles
        public ActionResult Index()
        {
            var courseFiles = db.CourseFiles.Include(c => c.Course);
            return View(courseFiles.ToList());
        }

        // GET: CourseFiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseFile courseFile = db.CourseFiles.Find(id);
            if (courseFile == null)
            {
                return HttpNotFound();
            }
            return View(courseFile);
        }

        // GET: CourseFiles/Create
        public ActionResult Create()
        {
           // var uid = User.Identity.Name;
            var getUid = db.Users.First(u => u.UserName == User.Identity.Name);
            var iid = db.Courses.First(u => u.InstructorID == getUid.Id);
            //int id = iid.ID;
            
            var cid = db.Courses.First(u => u.ID == iid.ID);
            //List<int> ids = new List<int>();
            //foreach (var m in cid)
            //{
            //    ids.Add(m.ID);
            //}
            //int s = ids.Count-1;
           // for(int i = 0;i<cid.;i++)
           
            {
                ViewBag.CourseID = new SelectList(db.Courses.Where(d => d.ID == cid.ID), "ID", "Title");
            }
           
            return View();
           
        }

        // POST: CourseFiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CourseID,File")] CourseFile courseFile)
        {
            if (ModelState.IsValid)
            {
                db.CourseFiles.Add(courseFile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "ID", "Title", courseFile.CourseID);
            return View(courseFile);
        }

        // GET: CourseFiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseFile courseFile = db.CourseFiles.Find(id);
            if (courseFile == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "Title", courseFile.CourseID);
            return View(courseFile);
        }

        // POST: CourseFiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CourseID,File")] CourseFile courseFile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseFile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "Title", courseFile.CourseID);
            return View(courseFile);
        }

        // GET: CourseFiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseFile courseFile = db.CourseFiles.Find(id);
            if (courseFile == null)
            {
                return HttpNotFound();
            }
            return View(courseFile);
        }

        // POST: CourseFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseFile courseFile = db.CourseFiles.Find(id);
            db.CourseFiles.Remove(courseFile);
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
