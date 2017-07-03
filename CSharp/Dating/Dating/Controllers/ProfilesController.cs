using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dating.Data;
using Microsoft.AspNet.Identity;

namespace Dating.Controllers
{
    public class ProfilesController : Controller
    {
        private DatingDbContext db = new DatingDbContext();

        // GET: Profiles
        public ActionResult Index()
        {
            var profiles = db.Profiles.Include(p => p.User);
            return View(profiles.ToList());
        }

        // GET: Profiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // GET: Profiles/Create
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Profiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Sex,DateOfBirth,Height,Weitght,Country,Town,Relationship,Children,Sign,Ocupation,Smoker,Drinker,LookingFor,Resume,UserId")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();

                var prof = new Profile
                {
                    Name = profile.Name,
                    Sex = profile.Sex,
                    DateOfBirth = profile.DateOfBirth,
                    Height = profile.Height,
                    Weitght = profile.Weitght,
                    Country = profile.Country,
                    Town = profile.Town,
                    Relationship = profile.Relationship,
                    Children = profile.Children,
                    Sign = profile.Sign,
                    Ocupation = profile.Ocupation,
                    Languages = profile.Languages,
                    Smoker = profile.Smoker,
                    Drinker = profile.Drinker,
                    LookingFor = profile.LookingFor,
                    Resume = profile.Resume,
                    
                };


                db.Profiles.Add(profile);
                db.SaveChanges();
                return RedirectToAction("Details", new {id = prof.Id});
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", profile.UserId);
            return View(profile);
        }

        // GET: Profiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", profile.UserId);
            return View(profile);
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Sex,DateOfBirth,Height,Weitght,Country,Town,Relationship,Children,Sign,Ocupation,Smoker,Drinker,LookingFor,Resume,UserId")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", profile.UserId);
            return View(profile);
        }

        // GET: Profiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profile profile = db.Profiles.Find(id);
            db.Profiles.Remove(profile);
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
