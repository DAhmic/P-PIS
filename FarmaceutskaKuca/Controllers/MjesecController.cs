using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FarmaceutskaKuca.Models;

namespace FarmaceutskaKuca.Controllers
{
    public class MjesecController : Controller
    {
        private mydbEntities db = new mydbEntities();

        // GET: Mjesec
        public ActionResult Index()
        {
            return View(db.mjesec.ToList());
        }

        // GET: Mjesec/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mjesec mjesec = db.mjesec.Find(id);
            if (mjesec == null)
            {
                return HttpNotFound();
            }
            return View(mjesec);
        }

        // GET: Mjesec/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mjesec/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,naziv")] mjesec mjesec)
        {
            if (ModelState.IsValid)
            {
                db.mjesec.Add(mjesec);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mjesec);
        }

        // GET: Mjesec/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mjesec mjesec = db.mjesec.Find(id);
            if (mjesec == null)
            {
                return HttpNotFound();
            }
            return View(mjesec);
        }

        // POST: Mjesec/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,naziv")] mjesec mjesec)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mjesec).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mjesec);
        }

        // GET: Mjesec/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mjesec mjesec = db.mjesec.Find(id);
            if (mjesec == null)
            {
                return HttpNotFound();
            }
            return View(mjesec);
        }

        // POST: Mjesec/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mjesec mjesec = db.mjesec.Find(id);
            db.mjesec.Remove(mjesec);
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
