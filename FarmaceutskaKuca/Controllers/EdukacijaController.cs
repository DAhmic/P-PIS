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
    public class EdukacijaController : Controller
    {
        private mydbEntities db = new mydbEntities();

        // GET: Edukacija
        public ActionResult Index()
        {
            return View(db.edukacija.ToList());
        }

        // GET: Edukacija
        public ActionResult IndexK()
        {
            return View(db.edukacija.ToList());
        }

        // GET: Edukacija/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            edukacija edukacija = db.edukacija.Find(id);
            if (edukacija == null)
            {
                return HttpNotFound();
            }
            return View(edukacija);
        }

        // GET: Edukacija/Details/5
        public ActionResult Prijava(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            edukacija edukacija = db.edukacija.Find(id);
            if (edukacija == null)
            {
                return HttpNotFound();
            }
            return View(edukacija);
        }

        // GET: Edukacija/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Edukacija/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,naziv,opis,kategorija,trajanje")] edukacija edukacija)
        {
            if (ModelState.IsValid)
            {
                db.edukacija.Add(edukacija);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(edukacija);
        }

        // GET: Edukacija/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            edukacija edukacija = db.edukacija.Find(id);
            if (edukacija == null)
            {
                return HttpNotFound();
            }
            return View(edukacija);
        }

        // POST: Edukacija/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,naziv,opis,kategorija,trajanje")] edukacija edukacija)
        {
            if (ModelState.IsValid)
            {
                db.Entry(edukacija).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(edukacija);
        }

        // GET: Edukacija/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            edukacija edukacija = db.edukacija.Find(id);
            if (edukacija == null)
            {
                return HttpNotFound();
            }
            return View(edukacija);
        }

        // POST: Edukacija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            edukacija edukacija = db.edukacija.Find(id);
            db.edukacija.Remove(edukacija);
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
