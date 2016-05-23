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
    public class PlanController : Controller
    {
        private mydbEntities db = new mydbEntities();

        // GET: Plan
        public ActionResult Index()
        {
            var plan = db.plan.Include(p => p.servisxrizik);
            return View(plan.ToList());
        }

        // GET: Plan
        public ActionResult IndexK()
        {
            var plan = db.plan.Include(p => p.servisxrizik);
            return View(plan.ToList());
        }

        // GET: Plan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            plan plan = db.plan.Find(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // GET: Plan/Details/5
        public ActionResult DetailsK(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            plan plan = db.plan.Find(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // GET: Plan/Create
        public ActionResult Create()
        {
            //ViewBag.id_sxr = new SelectList(db.servisxrizik, "id", "procenat");
            ViewBag.id_sxr = new SelectList(db.servisxrizik, "id", "naziv");
            return View();
        }

        // GET: Plan/Create
        public ActionResult CreateK()
        {
            //ViewBag.id_sxr = new SelectList(db.servisxrizik, "id", "procenat");
            ViewBag.id_sxr = new SelectList(db.servisxrizik, "id", "naziv");
            return View();
        }

        // POST: Plan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_sxr,preventivne_strategije,strategije_odgovora,strategije_oporavka,testiran,napomena_k,napomena_m")] plan plan)
        {
            if (ModelState.IsValid)
            {
                db.plan.Add(plan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.id_sxr = new SelectList(db.servisxrizik, "id", "procenat", plan.id_sxr);
            ViewBag.id_sxr = new SelectList(db.servisxrizik, "id", "naziv", plan.id_sxr);
            return View(plan);
        }

        // POST: Plan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateK([Bind(Include = "id,id_sxr,preventivne_strategije,strategije_odgovora,strategije_oporavka,testiran,napomena_k,napomena_m")] plan plan)
        {
            if (ModelState.IsValid)
            {
                db.plan.Add(plan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.id_sxr = new SelectList(db.servisxrizik, "id", "procenat", plan.id_sxr);
            ViewBag.id_sxr = new SelectList(db.servisxrizik, "id", "naziv", plan.id_sxr);
            return View(plan);
        }

        // GET: Plan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            plan plan = db.plan.Find(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_sxr = new SelectList(db.servisxrizik, "id", "naziv", plan.id_sxr);
            return View(plan);
        }

        // GET: Plan/Edit/5
        public ActionResult EditK(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            plan plan = db.plan.Find(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_sxr = new SelectList(db.servisxrizik, "id", "naziv", plan.id_sxr);
            return View(plan);
        }

        // POST: Plan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_sxr,preventivne_strategije,strategije_odgovora,strategije_oporavka,testiran,napomena_k,napomena_m")] plan plan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_sxr = new SelectList(db.servisxrizik, "id", "naziv", plan.id_sxr);
            return View(plan);
        }

        // POST: Plan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditK([Bind(Include = "id,id_sxr,preventivne_strategije,strategije_odgovora,strategije_oporavka,testiran,napomena_k,napomena_m")] plan plan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_sxr = new SelectList(db.servisxrizik, "id", "naziv", plan.id_sxr);
            return View(plan);
        }

        // GET: Plan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            plan plan = db.plan.Find(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // POST: Plan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            plan plan = db.plan.Find(id);
            db.plan.Remove(plan);
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
