using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FastLearn.com.Models;
using FastLearn.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace FastLearn.com.Controllers
{
    public class InstructorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Instructor
        public ActionResult Index()
        {
            return View(db.Instructors.ToList());
        }

        // GET: Instructor/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = db.Instructors.Find(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }
        [Authorize]
        [Authorize(Roles = "Student")]
       // [Authorize(Roles = "Admin")]
        // GET: Instructor/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Instructor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles ="Student")]
        [HttpPost]
        [ValidateAntiForgeryToken]
       // [Authorize]
       // [Authorize(Roles ="Student")]
      //  [Authorize(Roles ="Admin")]
        public ActionResult Create(Instructor instructor)
        {
            var UserID = db.Users.First(u => u.UserName == User.Identity.Name);
            
            string id = UserID.Email;
            var UserData = db.Students.First(u => u.ID == id);
            if (!db.Instructors.Any(u => u.ID == UserID.Id)&&!User.IsInRole("Instructor"))
            {
                var userStore = new UserStore<ApplicationUser>(db);
                //setting to the userManager to access direct access
                var userManager = new UserManager<ApplicationUser>(userStore);
                instructor = new Instructor { ID = id,FirstName = UserData.FirstName,LastName = UserData.LastName,image = UserData.Image
                , Biography = UserData.Biography,JoinedDate = DateTime.Now};
                userManager.AddToRole(User.Identity.GetUserId(),"Instructor");
                db.Instructors.Add(instructor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(instructor);
        }

        // GET: Instructor/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = db.Instructors.Find(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        // POST: Instructor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,image,Biography")] Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instructor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(instructor);
        }

        // GET: Instructor/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = db.Instructors.Find(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        // POST: Instructor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Instructor instructor = db.Instructors.Find(id);
            db.Instructors.Remove(instructor);
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
