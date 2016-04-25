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
    public class KorisnikController : Controller
    {
        private mydbEntities db = new mydbEntities();

        // GET: Korisnik
        public ActionResult Index()
        {
            var korisnik = db.korisnik.Include(k => k.tip);
            return View(korisnik.ToList());
        }

        // GET: Korisnik/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            korisnik korisnik = db.korisnik.Find(id);
            if (korisnik == null)
            {
                return HttpNotFound();
            }
            return View(korisnik);
        }

        // GET: Korisnik/Create
        public ActionResult Create()
        {
            ViewBag.Tip_id = new SelectList(db.tip, "id", "naziv");
            return View();
        }

        // POST: Korisnik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,username,password,ime,prezime,Tip_id")] korisnik korisnik)
        {
            if (ModelState.IsValid)
            {
                db.korisnik.Add(korisnik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Tip_id = new SelectList(db.tip, "id", "naziv", korisnik.Tip_id);
            return View(korisnik);
        }

        // GET: Korisnik/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            korisnik korisnik = db.korisnik.Find(id);
            if (korisnik == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tip_id = new SelectList(db.tip, "id", "naziv", korisnik.Tip_id);
            return View(korisnik);
        }

        // POST: Korisnik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,username,password,ime,prezime,Tip_id")] korisnik korisnik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(korisnik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Tip_id = new SelectList(db.tip, "id", "naziv", korisnik.Tip_id);
            return View(korisnik);
        }

        // GET: Korisnik/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            korisnik korisnik = db.korisnik.Find(id);
            if (korisnik == null)
            {
                return HttpNotFound();
            }
            return View(korisnik);
        }

        // POST: Korisnik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            korisnik korisnik = db.korisnik.Find(id);
            db.korisnik.Remove(korisnik);
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
