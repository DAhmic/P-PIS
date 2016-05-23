using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FarmaceutskaKuca.Models;

namespace FarmaceutskaKuca.Controllers
{
    public class HomeController : Controller
    {
        private mydbEntities db = new mydbEntities();
        public ActionResult Index()
        {
            if (Session["KorisnikId"] as string == null || Session["KorisnikIme"] as string == null || Session["KorisnikId"] as string == "" || Session["KorisnikIme"] as string == "")
                return RedirectToAction("Login", "Account");
            else if(Session["KorisnikId"] as string != null && Session["KorisnikIme"] as string != null && Session["KorisnikId"] as string != "" && Session["KorisnikIme"] as string != "")
            {
                int idKorisnika = Convert.ToInt32(Session["KorisnikId"]);
                var korisnik = db.korisnik.Find(idKorisnika);
                if(korisnik.tip.naziv == "admin")
                {
                    Session["admin"] = "admin";
                }
                if (korisnik.tip.naziv == "incidentM")
                {
                    Session["incidentM"] = "incidentM";
                }

                if (korisnik.tip.naziv == "knowledgeM")
                {
                    Session["knowledgeM"] = "knowledgeM";
                }

                if (korisnik.tip.naziv == "continuityM")
                {
                    Session["continuityM"] = "continuityM";
                }

                if (korisnik.tip.naziv == "korisnik")
                {
                    Session["korisnik"] = "korisnik";
                }
                return View();
            }
            return RedirectToAction("Login", "Account");
            //return View();
        }

        public ActionResult IndexIM()
        {
            if (Session["KorisnikId"] as string == null || Session["KorisnikIme"] as string == null || Session["KorisnikId"] as string == "" || Session["KorisnikIme"] as string == "")
                return RedirectToAction("Login", "Account");
            else if (Session["KorisnikId"] as string != null && Session["KorisnikIme"] as string != null && Session["KorisnikId"] as string != "" && Session["KorisnikIme"] as string != "")
            {
                int idKorisnika = Convert.ToInt32(Session["KorisnikId"]);
                var korisnik = db.korisnik.Find(idKorisnika);
                if (korisnik.tip.naziv == "admin")
                {
                    Session["admin"] = "admin";
                }
                if (korisnik.tip.naziv == "incidentM")
                {
                    Session["incidentM"] = "incidentM";
                }

                if (korisnik.tip.naziv == "knowledgeM")
                {
                    Session["knowledgeM"] = "knowledgeM";
                }

                if (korisnik.tip.naziv == "continuityM")
                {
                    Session["continuityM"] = "continuityM";
                }

                if (korisnik.tip.naziv == "korisnik")
                {
                    Session["korisnik"] = "korisnik";
                }
                return View();
            }
            return RedirectToAction("Login", "Account");
            //return View();
        }

        public ActionResult IndexKM()
        {
            if (Session["KorisnikId"] as string == null || Session["KorisnikIme"] as string == null || Session["KorisnikId"] as string == "" || Session["KorisnikIme"] as string == "")
                return RedirectToAction("Login", "Account");
            else if (Session["KorisnikId"] as string != null && Session["KorisnikIme"] as string != null && Session["KorisnikId"] as string != "" && Session["KorisnikIme"] as string != "")
            {
                int idKorisnika = Convert.ToInt32(Session["KorisnikId"]);
                var korisnik = db.korisnik.Find(idKorisnika);
                if (korisnik.tip.naziv == "admin")
                {
                    Session["admin"] = "admin";
                }
                if (korisnik.tip.naziv == "incidentM")
                {
                    Session["incidentM"] = "incidentM";
                }

                if (korisnik.tip.naziv == "knowledgeM")
                {
                    Session["knowledgeM"] = "knowledgeM";
                }

                if (korisnik.tip.naziv == "continuityM")
                {
                    Session["continuityM"] = "continuityM";
                }

                if (korisnik.tip.naziv == "korisnik")
                {
                    Session["korisnik"] = "korisnik";
                }
                return View();
            }
            return RedirectToAction("Login", "Account");
            //return View();
        }

        public ActionResult IndexITSCM()
        {
            if (Session["KorisnikId"] as string == null || Session["KorisnikIme"] as string == null || Session["KorisnikId"] as string == "" || Session["KorisnikIme"] as string == "")
                return RedirectToAction("Login", "Account");
            else if (Session["KorisnikId"] as string != null && Session["KorisnikIme"] as string != null && Session["KorisnikId"] as string != "" && Session["KorisnikIme"] as string != "")
            {
                int idKorisnika = Convert.ToInt32(Session["KorisnikId"]);
                var korisnik = db.korisnik.Find(idKorisnika);
                if (korisnik.tip.naziv == "admin")
                {
                    Session["admin"] = "admin";
                }
                if (korisnik.tip.naziv == "incidentM")
                {
                    Session["incidentM"] = "incidentM";
                }

                if (korisnik.tip.naziv == "knowledgeM")
                {
                    Session["knowledgeM"] = "knowledgeM";
                }

                if (korisnik.tip.naziv == "continuityM")
                {
                    Session["continuityM"] = "continuityM";
                }

                if (korisnik.tip.naziv == "korisnik")
                {
                    Session["korisnik"] = "korisnik";
                }
                return View();
            }
            return RedirectToAction("Login", "Account");
            //return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}