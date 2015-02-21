﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web.DAL;
using Web.Models;

namespace Web.Controllers
{
    public class RsvpController : Controller
    {
        private SamAndGraceContext db = new SamAndGraceContext();

        // GET: Rsvp
        public ActionResult Index()
        {
            return View(db.Rsvps.ToList());
        }

        // GET: Rsvp/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rsvp rsvp = db.Rsvps.Find(id);
            if (rsvp == null)
            {
                return HttpNotFound();
            }
            return View(rsvp);
        }

        // GET: Rsvp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rsvp/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Attending,RequiresTransport,DietryRequirements")] Rsvp rsvp)
        {
            if (ModelState.IsValid)
            {
                db.Rsvps.Add(rsvp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rsvp);
        }

        // GET: Rsvp/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rsvp rsvp = db.Rsvps.Find(id);
            if (rsvp == null)
            {
                return HttpNotFound();
            }
            return View(rsvp);
        }

        // POST: Rsvp/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Attending,RequiresTransport,DietryRequirements")] Rsvp rsvp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rsvp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rsvp);
        }

        // GET: Rsvp/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rsvp rsvp = db.Rsvps.Find(id);
            if (rsvp == null)
            {
                return HttpNotFound();
            }
            return View(rsvp);
        }

        // POST: Rsvp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rsvp rsvp = db.Rsvps.Find(id);
            db.Rsvps.Remove(rsvp);
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
