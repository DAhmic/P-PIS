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
    public class RizikController : Controller
    {
        private mydbEntities db = new mydbEntities();

        // GET: Rizik
        public ActionResult Index()
        {
            return View(db.rizik.ToList());
        }

        // GET: Rizik/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rizik rizik = db.rizik.Find(id);
            if (rizik == null)
            {
                return HttpNotFound();
            }
            return View(rizik);
        }

        // GET: Rizik/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rizik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,naziv")] rizik rizik)
        {
            if (ModelState.IsValid)
            {
                db.rizik.Add(rizik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rizik);
        }

        // GET: Rizik/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rizik rizik = db.rizik.Find(id);
            if (rizik == null)
            {
                return HttpNotFound();
            }
            return View(rizik);
        }

        // POST: Rizik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,naziv")] rizik rizik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rizik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rizik);
        }

        // GET: Rizik/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rizik rizik = db.rizik.Find(id);
            if (rizik == null)
            {
                return HttpNotFound();
            }
            return View(rizik);
        }

        // POST: Rizik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rizik rizik = db.rizik.Find(id);
            db.rizik.Remove(rizik);
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
