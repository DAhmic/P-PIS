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
    public class ServisXRizikController : Controller
    {
        private mydbEntities db = new mydbEntities();

        // GET: ServisXRizik
        public ActionResult Index()
        {
            var servisxrizik = db.servisxrizik.Include(s => s.rizik).Include(s => s.servis);
            return View(servisxrizik.ToList());
        }

        // GET: ServisXRizik/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            servisxrizik servisxrizik = db.servisxrizik.Find(id);
            if (servisxrizik == null)
            {
                return HttpNotFound();
            }
            return View(servisxrizik);
        }

        // GET: ServisXRizik/Create
        public ActionResult Create()
        {
            ViewBag.id_r = new SelectList(db.rizik, "id", "naziv");
            ViewBag.id_s = new SelectList(db.servis, "id", "naziv");
            return View();
        }

        // POST: ServisXRizik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_s,id_r,procenat,naziv")] servisxrizik servisxrizik)
        {
            if (ModelState.IsValid)
            {
                db.servisxrizik.Add(servisxrizik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_r = new SelectList(db.rizik, "id", "naziv", servisxrizik.id_r);
            ViewBag.id_s = new SelectList(db.servis, "id", "naziv", servisxrizik.id_s);
            return View(servisxrizik);
        }

        // GET: ServisXRizik/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            servisxrizik servisxrizik = db.servisxrizik.Find(id);
            if (servisxrizik == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_r = new SelectList(db.rizik, "id", "naziv", servisxrizik.id_r);
            ViewBag.id_s = new SelectList(db.servis, "id", "naziv", servisxrizik.id_s);
            return View(servisxrizik);
        }

        // POST: ServisXRizik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_s,id_r,procenat,naziv")] servisxrizik servisxrizik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servisxrizik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_r = new SelectList(db.rizik, "id", "naziv", servisxrizik.id_r);
            ViewBag.id_s = new SelectList(db.servis, "id", "naziv", servisxrizik.id_s);
            return View(servisxrizik);
        }

        // GET: ServisXRizik/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            servisxrizik servisxrizik = db.servisxrizik.Find(id);
            if (servisxrizik == null)
            {
                return HttpNotFound();
            }
            return View(servisxrizik);
        }

        // POST: ServisXRizik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            servisxrizik servisxrizik = db.servisxrizik.Find(id);
            db.servisxrizik.Remove(servisxrizik);
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
