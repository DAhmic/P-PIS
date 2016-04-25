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
    public class Baza_znanjaController : Controller
    {
        private mydbEntities db = new mydbEntities();

        // GET: Baza_znanja
        /* public ActionResult Index()
         {
             var baza_znanja = db.baza_znanja.Include(b => b.kategorija);
             return View(baza_znanja.ToList());
         }*/

        // GET: Baza_znanja
        public ActionResult Index(string category, string searchString)
        {
            ViewBag.category = new SelectList(db.kategorija, "naziv", "naziv");

            var incidenti = from i in db.baza_znanja
                            select i;

            if (!String.IsNullOrEmpty(searchString))
            {
                incidenti = incidenti.Where(s => s.naziv_incidenta.Contains(searchString));

            }
            
            if (!String.IsNullOrEmpty(category))
            {
                incidenti = incidenti.Where(x => x.kategorija.naziv == category);

            }

            return View(incidenti.Include(b => b.kategorija));
        }

        // GET: Baza_znanja/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            baza_znanja baza_znanja = db.baza_znanja.Find(id);
            if (baza_znanja == null)
            {
                return HttpNotFound();
            }
            return View(baza_znanja);
        }

        // GET: Baza_znanja/Create
        public ActionResult Create()
        {
            ViewBag.id_k = new SelectList(db.kategorija, "id", "naziv");
            return View();
        }

        // POST: Baza_znanja/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,naziv_incidenta,rjesenje,id_k")] baza_znanja baza_znanja)
        {
            if (ModelState.IsValid)
            {
                db.baza_znanja.Add(baza_znanja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_k = new SelectList(db.kategorija, "id", "naziv", baza_znanja.id_k);
            return View(baza_znanja);
        }

        // GET: Baza_znanja/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            baza_znanja baza_znanja = db.baza_znanja.Find(id);
            if (baza_znanja == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_k = new SelectList(db.kategorija, "id", "naziv", baza_znanja.id_k);
            return View(baza_znanja);
        }

        // POST: Baza_znanja/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,naziv_incidenta,rjesenje,id_k")] baza_znanja baza_znanja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baza_znanja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_k = new SelectList(db.kategorija, "id", "naziv", baza_znanja.id_k);
            return View(baza_znanja);
        }

        // GET: Baza_znanja/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            baza_znanja baza_znanja = db.baza_znanja.Find(id);
            if (baza_znanja == null)
            {
                return HttpNotFound();
            }
            return View(baza_znanja);
        }

        // POST: Baza_znanja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            baza_znanja baza_znanja = db.baza_znanja.Find(id);
            db.baza_znanja.Remove(baza_znanja);
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
