using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ads.Helpers;
using Ads.Models;
using Microsoft.AspNet.Identity;

namespace Ads.Controllers
{
    public class AdsController : Controller
    {
        private AdsDbContext db = new AdsDbContext();

        public ActionResult Index()
        {
            var currentUser = User.Identity.GetUserId();
            var ads = db.Ads.Include(a => a.User)
                .OrderByDescending(a => a.Id)
                .Where(c => c.UserId == currentUser);
            return View(ads.ToList());
        }

        // GET: Ads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ad ad = db.Ads.Find(id);
            if (ad == null)
            {
                return HttpNotFound();
            }

            return View(ad);
 }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Condition,Description,Price,Category,City,IsActive,ImageUrl,UserId")] Ad ad,
            HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string fileName = "";

                if (file != null && file.ContentLength > 0)
                    try
                    {
                        fileName = Path.GetFileName(file.FileName);
                        string folder = Server.MapPath(Url.Content("~/Data/Images"));

                        string pathToSave = Path.Combine(folder, fileName);
                        file.SaveAs(pathToSave);
                        ViewBag.Message = "File uploaded successfully";
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    }
                else
                {
                    ViewBag.Message = "You have not specified a file.";
                }

                var userId = this.User.Identity.GetUserId();

                var newAd = new Ad
                {
                    Title = ad.Title,
                    Condition = ad.Condition,
                    Description = ad.Description,
                    Price = ad.Price,
                    Category = ad.Category,
                    City = ad.City,
                    IsActive = ad.IsActive,
                    ImageUrl = fileName,
                    UserId = userId
                };

                db.Ads.Add(newAd);
                db.SaveChanges();
                return RedirectToAction("Details", new {id = newAd.Id});
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", ad.UserId);
            return View(ad);
        }

        // GET: Ads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ad ad = db.Ads.Find(id);
            if (ad == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", ad.UserId);
            return View(ad);
        }

        // POST: Ads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Condition,Description,Price,Category,City,IsActive,ImageUrl,UserId")] Ad ad)
        {
            if (ModelState.IsValid)
            {
                var editedAd = new Ad
                {
                    Id = ad.Id,
                    Title = ad.Title,
                    Condition = ad.Condition,
                    Description = ad.Description,
                    Price = ad.Price,
                    Category = ad.Category,
                    City = ad.City,
                    IsActive = ad.IsActive,
                    ImageUrl = ad.ImageUrl,
                    UserId = ad.UserId
                };
                db.Entry(editedAd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = editedAd.Id });
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", ad.UserId);
            return View(ad);
        }

        // GET: Ads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ad ad = db.Ads.Find(id);
            if (ad == null)
            {
                return HttpNotFound();
            }
            return View(ad);
        }

        // POST: Ads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ad ad = db.Ads.Find(id);
            db.Ads.Remove(ad);
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
