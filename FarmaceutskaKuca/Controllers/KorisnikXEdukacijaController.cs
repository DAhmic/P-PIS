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
    public class KorisnikXEdukacijaController : Controller
    {
        private mydbEntities db = new mydbEntities();

        // GET: KorisnikXEdukacija
        public ActionResult Index()
        {
            var korisnikxedukacija = db.korisnikxedukacija.Include(k => k.edukacija).Include(k => k.korisnik);
            return View(korisnikxedukacija.ToList());
        }

        // GET: KorisnikXEdukacija/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            korisnikxedukacija korisnikxedukacija = db.korisnikxedukacija.Find(id);
            if (korisnikxedukacija == null)
            {
                return HttpNotFound();
            }
            return View(korisnikxedukacija);
        }

        // GET: KorisnikXEdukacija/Create
        public ActionResult Create()
        {
            ViewBag.id_e = new SelectList(db.edukacija, "id", "naziv");
            ViewBag.id_k = new SelectList(db.korisnik, "id", "username");
            return View();
        }

        // POST: KorisnikXEdukacija/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_k,id_e,odobreno")] korisnikxedukacija korisnikxedukacija)
        {
            if (ModelState.IsValid)
            {
                db.korisnikxedukacija.Add(korisnikxedukacija);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_e = new SelectList(db.edukacija, "id", "naziv", korisnikxedukacija.id_e);
            ViewBag.id_k = new SelectList(db.korisnik, "id", "username", korisnikxedukacija.id_k);
            return View(korisnikxedukacija);
        }

        // GET: KorisnikXEdukacija/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            korisnikxedukacija korisnikxedukacija = db.korisnikxedukacija.Find(id);
            if (korisnikxedukacija == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_e = new SelectList(db.edukacija, "id", "naziv", korisnikxedukacija.id_e);
            ViewBag.id_k = new SelectList(db.korisnik, "id", "username", korisnikxedukacija.id_k);
            return View(korisnikxedukacija);
        }

        // POST: KorisnikXEdukacija/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_k,id_e,odobreno")] korisnikxedukacija korisnikxedukacija)
        {
            if (ModelState.IsValid)
            {
                db.Entry(korisnikxedukacija).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_e = new SelectList(db.edukacija, "id", "naziv", korisnikxedukacija.id_e);
            ViewBag.id_k = new SelectList(db.korisnik, "id", "username", korisnikxedukacija.id_k);
            return View(korisnikxedukacija);
        }

        // GET: KorisnikXEdukacija/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            korisnikxedukacija korisnikxedukacija = db.korisnikxedukacija.Find(id);
            if (korisnikxedukacija == null)
            {
                return HttpNotFound();
            }
            return View(korisnikxedukacija);
        }

        // POST: KorisnikXEdukacija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            korisnikxedukacija korisnikxedukacija = db.korisnikxedukacija.Find(id);
            db.korisnikxedukacija.Remove(korisnikxedukacija);
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
