﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using photographers.Models;

namespace photographers.Controllers
{
    public class locationsController : Controller
    {
        private ModelDBcontext db = new ModelDBcontext();

        // GET: locations
        public ActionResult Index()
        {
            return View(db.locations.ToList());
        }

        // GET: locations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            location location = db.locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // GET: locations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: locations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDlocation,location1,locationURL,Describtion")] location location, HttpPostedFileBase locationIMG)
        {
            if (ModelState.IsValid)
            {
                string filename = locationIMG.FileName;
                string path = Server.MapPath("/content/IMG/locations/" + filename);
                locationIMG.SaveAs(path);
                location.locationURL = filename;
                db.locations.Add(location);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(location);
        }

        // GET: locations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            location location = db.locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // POST: locations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDlocation,location1,locationURL,Describtion")] location location)
        {
            if (ModelState.IsValid)
            {
                db.Entry(location).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(location);
        }

        // GET: locations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            location location = db.locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // POST: locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            location location = db.locations.Find(id);
            db.locations.Remove(location);
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
