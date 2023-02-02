using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using photographers.Models;

namespace photographers.Controllers
{
    public class PhotographersController : Controller
    {
        private ModelDBcontext db = new ModelDBcontext();

        // GET: Photographers
        public ActionResult Index()
        {
            var photographers = db.Photographers.Include(p => p.portfolio);
            return View(photographers.ToList());
        }

        // GET: Photographers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photographer photographer = db.Photographers.Find(id);
            if (photographer == null)
            {
                return HttpNotFound();
            }
            return View(photographer);
        }

        // GET: Photographers/Create
        public ActionResult Create()
        {
            ViewBag.IDportafolio = new SelectList(db.portfolios, "IDportfoglio", "aboutme");
            return View();
        }

        // POST: Photographers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDphotographer,FirstName,LastName,website,instagram,profileImgURL,tel,email,experienceThan,IDportafolio")] Photographer photographer)
        {
            if (ModelState.IsValid)
            {
                db.Photographers.Add(photographer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDportafolio = new SelectList(db.portfolios, "IDportfoglio", "aboutme", photographer.IDportafolio);
            return View(photographer);
        }

        // GET: Photographers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photographer photographer = db.Photographers.Find(id);
            if (photographer == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDportafolio = new SelectList(db.portfolios, "IDportfoglio", "aboutme", photographer.IDportafolio);
            return View(photographer);
        }

        // POST: Photographers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDphotographer,FirstName,LastName,website,instagram,profileImgURL,tel,email,experienceThan,IDportafolio")] Photographer photographer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(photographer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDportafolio = new SelectList(db.portfolios, "IDportfoglio", "aboutme", photographer.IDportafolio);
            return View(photographer);
        }

        // GET: Photographers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photographer photographer = db.Photographers.Find(id);
            if (photographer == null)
            {
                return HttpNotFound();
            }
            return View(photographer);
        }

        // POST: Photographers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Photographer photographer = db.Photographers.Find(id);
            db.Photographers.Remove(photographer);
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
