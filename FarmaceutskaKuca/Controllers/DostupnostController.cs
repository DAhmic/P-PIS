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
    public class DostupnostController : Controller
    {
        private mydbEntities db = new mydbEntities();

        // GET: Dostupnost
        public ActionResult Index()
        {
            var dostupnost = db.dostupnost.Include(d => d.servis).Include(d => d.mjesec);
            return View(dostupnost.ToList());
        }

        // GET: Dostupnost/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dostupnost dostupnost = db.dostupnost.Find(id);
            if (dostupnost == null)
            {
                return HttpNotFound();
            }
            return View(dostupnost);
        }

        // GET: Dostupnost/Chart/5
        public ActionResult Chart(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dostupnost dostupnost = db.dostupnost.Find(id);
            if (dostupnost == null)
            {
                return HttpNotFound();
            }
            return View(dostupnost);
        }

        // GET: Dostupnost/Create
        public ActionResult Create()
        {
            ViewBag.id_s = new SelectList(db.servis, "id", "naziv");
            ViewBag.id_m = new SelectList(db.mjesec, "id", "naziv");
            return View();
        }

        // POST: Dostupnost/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_s,id_m,procenat")] dostupnost dostupnost)
        {
            if (ModelState.IsValid)
            {
                db.dostupnost.Add(dostupnost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_s = new SelectList(db.servis, "id", "naziv", dostupnost.id_s);
            ViewBag.id_m = new SelectList(db.mjesec, "id", "naziv", dostupnost.id_m);
            return View(dostupnost);
        }

        // GET: Dostupnost/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dostupnost dostupnost = db.dostupnost.Find(id);
            if (dostupnost == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_s = new SelectList(db.servis, "id", "naziv", dostupnost.id_s);
            ViewBag.id_m = new SelectList(db.mjesec, "id", "naziv", dostupnost.id_m);
            return View(dostupnost);
        }

        // POST: Dostupnost/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_s,id_m,procenat")] dostupnost dostupnost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dostupnost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_s = new SelectList(db.servis, "id", "naziv", dostupnost.id_s);
            ViewBag.id_m = new SelectList(db.mjesec, "id", "naziv", dostupnost.id_m);
            return View(dostupnost);
        }

        // GET: Dostupnost/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dostupnost dostupnost = db.dostupnost.Find(id);
            if (dostupnost == null)
            {
                return HttpNotFound();
            }
            return View(dostupnost);
        }

        // POST: Dostupnost/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dostupnost dostupnost = db.dostupnost.Find(id);
            db.dostupnost.Remove(dostupnost);
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
