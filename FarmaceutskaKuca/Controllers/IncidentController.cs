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
    public class IncidentController : Controller
    {
        private mydbEntities db = new mydbEntities();

        // GET: Incident
        public ActionResult Index()
        {
            var incident = db.incident.Include(i => i.kategorija).Include(i => i.korisnik);
            incident = incident.OrderBy(i => i.vrijemePrijave);
            return View(incident.ToList());
        }

        // GET: Incident-IM
        public ActionResult IndexIM()
        {
            var incident = db.incident.Include(i => i.kategorija).Include(i => i.korisnik);
            incident = incident.OrderBy(i => i.vrijemePrijave);
            return View(incident.ToList());
        }

        // GET: Incident-K
        public ActionResult IndexK()
        {
            var incident = db.incident.Include(i => i.kategorija).Include(i => i.korisnik);
            incident = incident.OrderBy(i => i.vrijemePrijave);
            return View(incident.ToList());
        }

        // GET: Incident-KO
        public ActionResult IndexKO()
        {
            var incident = db.incident.Include(i => i.kategorija).Include(i => i.korisnik);
            incident = incident.OrderBy(i => i.vrijemePrijave);
            return View(incident.ToList());
        }

        // GET: Incident/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            incident incident = db.incident.Find(id);
            if (incident == null)
            {
                return HttpNotFound();
            }
            return View(incident);
        }

        // GET: Incident/DetailsIM/5
        public ActionResult DetailsIM(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            incident incident = db.incident.Find(id);
            if (incident == null)
            {
                return HttpNotFound();
            }
            return View(incident);
        }

        // GET: Incident/Details/5
        public ActionResult DetailsKO(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            incident incident = db.incident.Find(id);
            if (incident == null)
            {
                return HttpNotFound();
            }
            return View(incident);
        }

        // GET: Incident/Details/5
        public ActionResult DetailsIndex(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            incident incident = db.incident.Find(id);
            if (incident == null)
            {
                return HttpNotFound();
            }
            return View(incident);
        }

        // GET: Incident/Create
        public ActionResult Create()
        {
            ViewBag.Kategorija_id = new SelectList(db.kategorija, "id", "naziv");
            ViewBag.Korisnik_id = new SelectList(db.korisnik, "id", "username");
            return View();
        }

        // GET: Incident/CreateIM
        public ActionResult CreateIM()
        {
            ViewBag.Kategorija_id = new SelectList(db.kategorija, "id", "naziv");
            ViewBag.Korisnik_id = new SelectList(db.korisnik, "id", "username");
            return View();
        }

        // POST: Incident/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "vrijemePrijave,naziv,opis,Kategorija_id,prioritet,status,Napomena_M,Napomena_K")] incident incident)
        {

            if (ModelState.IsValid)
            {
                incident.Korisnik_id = Convert.ToInt32(Session["KorisnikId"]);
                //incident.Korisnik_id = 1;
                incident.vrijemePrijave = DateTime.Now;
                incident.prioritet = "";
                incident.status = "Otvoren";
                incident.Napomena_M = "";
                incident.Napomena_K = "";
                db.incident.Add(incident);
                db.SaveChanges();
                return RedirectToAction("IndexK", "Incident");
                //return RedirectToAction("Index");
            }

            ViewBag.Kategorija_id = new SelectList(db.kategorija, "id", "naziv", incident.Kategorija_id);
            ViewBag.Korisnik_id = new SelectList(db.korisnik, "id", "username", incident.Korisnik_id);
            return View(incident);
        }

        // POST: Incident/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateIM([Bind(Include = "vrijemePrijave,naziv,opis,Kategorija_id,prioritet,status,Napomena_M,Napomena_K")] incident incident)
        {

            if (ModelState.IsValid)
            {
                incident.Korisnik_id = Convert.ToInt32(Session["KorisnikId"]);
                //incident.Korisnik_id = 1;
                incident.vrijemePrijave = DateTime.Now;
                incident.prioritet = "";
                incident.status = "Otvoren";
                incident.Napomena_M = "";
                incident.Napomena_K = "";
                db.incident.Add(incident);
                db.SaveChanges();
                return RedirectToAction("IndexIM", "Incident");
                //return RedirectToAction("Index");
            }

            ViewBag.Kategorija_id = new SelectList(db.kategorija, "id", "naziv", incident.Kategorija_id);
            ViewBag.Korisnik_id = new SelectList(db.korisnik, "id", "username", incident.Korisnik_id);
            return View(incident);
        }

        // GET: Incident/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            incident incident = db.incident.Find(id);
            if (incident == null)
            {
                return HttpNotFound();
            }
            ViewBag.Kategorija_id = new SelectList(db.kategorija, "id", "naziv", incident.Kategorija_id);
            ViewBag.Korisnik_id = new SelectList(db.korisnik, "id", "username", incident.Korisnik_id);
            return View(incident);
        }

        // GET: Incident/EditK/5
        public ActionResult EditK(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            incident incident = db.incident.Find(id);
            if (incident == null)
            {
                return HttpNotFound();
            }
            ViewBag.Kategorija_id = new SelectList(db.kategorija, "id", "naziv", incident.Kategorija_id);
            ViewBag.Korisnik_id = new SelectList(db.korisnik, "id", "username", incident.Korisnik_id);
            return View(incident);
        }

        // POST: Incident/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,vrijemePrijave,naziv,opis,Kategorija_id,prioritet,status,Korisnik_id,Napomena_M,Napomena_K")] incident incident)
        {
            if (ModelState.IsValid)
            {
                bool odbijeno = false;
                if (incident.Napomena_K == "Odbijeno") {
                    odbijeno = true;                    
                }
                if (odbijeno)
                {
                    if (incident.status == "Zatvoren")
                    {
                        ModelState.AddModelError(string.Empty, "Korisnik nije odobrio rješenje incidenta");
                        ViewBag.Kategorija_id = new SelectList(db.kategorija, "id", "naziv", incident.Kategorija_id);
                        //ViewBag.Korisnik_id = new SelectList(db.korisnik, "id", "username", incident.Korisnik_id);
                        return View(incident);
                    }
                }
                db.Entry(incident).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexIM", "Incident");
                //return RedirectToAction("Index");
            }
            ViewBag.Kategorija_id = new SelectList(db.kategorija, "id", "naziv", incident.Kategorija_id);
            ViewBag.Korisnik_id = new SelectList(db.korisnik, "id", "username", incident.Korisnik_id);
            return View(incident);
        }

        // POST: Incident/EditK/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditK([Bind(Include = "id,vrijemePrijave,naziv,opis,Kategorija_id,prioritet,status,Korisnik_id,Napomena_M,Napomena_K")] incident incident)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incident).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexK", "Incident");
                //return RedirectToAction("Index");
            }
            ViewBag.Kategorija_id = new SelectList(db.kategorija, "id", "naziv", incident.Kategorija_id);
            ViewBag.Korisnik_id = new SelectList(db.korisnik, "id", "username", incident.Korisnik_id);
            return View(incident);
        }

        // GET: Incident/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            incident incident = db.incident.Find(id);
            if (incident == null)
            {
                return HttpNotFound();
            }
            return View(incident);
        }

        // POST: Incident/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            incident incident = db.incident.Find(id);
            db.incident.Remove(incident);
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
