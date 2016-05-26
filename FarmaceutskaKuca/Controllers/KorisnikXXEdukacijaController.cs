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
    public class KorisnikXXEdukacijaController : Controller
    {
        private mydbEntities db = new mydbEntities();

        // GET: KorisnikXXEdukacija
        public ActionResult Index()
        {
            var korisnikxxedukacija = db.korisnikxxedukacija.Include(k => k.edukacija).Include(k => k.korisnik);
            return View(korisnikxxedukacija.ToList());
        }

        // GET: KorisnikXXEdukacija/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            korisnikxxedukacija korisnikxxedukacija = db.korisnikxxedukacija.Find(id);
            if (korisnikxxedukacija == null)
            {
                return HttpNotFound();
            }
            return View(korisnikxxedukacija);
        }

        // GET: KorisnikXXEdukacija/Create
        public ActionResult Create()
        {
            ViewBag.id_e = new SelectList(db.edukacija, "id", "naziv");
            ViewBag.id_k = new SelectList(db.korisnik, "id", "username");
            return View();
        }

        // GET: KorisnikXXEdukacija/Create
        public ActionResult CreateK()
        {
            ViewBag.id_e = new SelectList(db.edukacija, "id", "naziv");
            ViewBag.id_k = new SelectList(db.korisnik, "id", "username");
            return View();
        }

        // POST: KorisnikXXEdukacija/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_k,id_e,odobreno")] korisnikxxedukacija korisnikxxedukacija)
        {
            if (ModelState.IsValid)
            {
                db.korisnikxxedukacija.Add(korisnikxxedukacija);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_e = new SelectList(db.edukacija, "id", "naziv", korisnikxxedukacija.id_e);
            ViewBag.id_k = new SelectList(db.korisnik, "id", "username", korisnikxxedukacija.id_k);
            return View(korisnikxxedukacija);
        }

        // POST: KorisnikXXEdukacija/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateK([Bind(Include = "id,id_k,id_e,odobreno")] korisnikxxedukacija korisnikxxedukacija)
        {
            if (ModelState.IsValid)
            {
                db.korisnikxxedukacija.Add(korisnikxxedukacija);
                db.SaveChanges();
                return RedirectToAction("IndexK", "Edukacija");
            }

            ViewBag.id_e = new SelectList(db.edukacija, "id", "naziv", korisnikxxedukacija.id_e);
            ViewBag.id_k = new SelectList(db.korisnik, "id", "username", korisnikxxedukacija.id_k);
            return View(korisnikxxedukacija);
        }

        // GET: KorisnikXXEdukacija/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            korisnikxxedukacija korisnikxxedukacija = db.korisnikxxedukacija.Find(id);
            if (korisnikxxedukacija == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_e = new SelectList(db.edukacija, "id", "naziv", korisnikxxedukacija.id_e);
            ViewBag.id_k = new SelectList(db.korisnik, "id", "username", korisnikxxedukacija.id_k);
            return View(korisnikxxedukacija);
        }

        // POST: KorisnikXXEdukacija/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_k,id_e,odobreno")] korisnikxxedukacija korisnikxxedukacija)
        {
            if (ModelState.IsValid)
            {
                db.Entry(korisnikxxedukacija).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_e = new SelectList(db.edukacija, "id", "naziv", korisnikxxedukacija.id_e);
            ViewBag.id_k = new SelectList(db.korisnik, "id", "username", korisnikxxedukacija.id_k);
            return View(korisnikxxedukacija);
        }

        // GET: KorisnikXXEdukacija/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            korisnikxxedukacija korisnikxxedukacija = db.korisnikxxedukacija.Find(id);
            if (korisnikxxedukacija == null)
            {
                return HttpNotFound();
            }
            return View(korisnikxxedukacija);
        }

        // POST: KorisnikXXEdukacija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            korisnikxxedukacija korisnikxxedukacija = db.korisnikxxedukacija.Find(id);
            db.korisnikxxedukacija.Remove(korisnikxxedukacija);
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
