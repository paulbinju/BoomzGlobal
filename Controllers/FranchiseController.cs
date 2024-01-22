using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BoomzGlobal.Models;

namespace BoomzGlobal.Controllers
{
    public class FranchiseController : Controller
    {
        private BoomzGlobalEntities db = new BoomzGlobalEntities();

        //
        // GET: /Franchise/

        public ActionResult Index()
        {
            var franchise_t = db.Franchise_T.Include(f => f.City_T).Include(f => f.Country_T);
            return View(franchise_t.ToList());
        }

        //
        // GET: /Franchise/Details/5

        public ActionResult Details(int id = 0)
        {
            Franchise_T franchise_t = db.Franchise_T.Find(id);
            if (franchise_t == null)
            {
                return HttpNotFound();
            }
            return View(franchise_t);
        }

        //
        // GET: /Franchise/Create

        public ActionResult Create()
        {
            ViewBag.CityID = new SelectList(db.City_T, "CityID", "City");
            ViewBag.CountryID = new SelectList(db.Country_T, "CountryID", "Country");
            return View();
        }

        //
        // POST: /Franchise/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Franchise_T franchise_t)
        {
            if (ModelState.IsValid)
            {
                db.Franchise_T.Add(franchise_t);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityID = new SelectList(db.City_T, "CityID", "City", franchise_t.CityID);
            ViewBag.CountryID = new SelectList(db.Country_T, "CountryID", "Country", franchise_t.CountryID);
            return View(franchise_t);
        }

        //
        // GET: /Franchise/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Franchise_T franchise_t = db.Franchise_T.Find(id);
            if (franchise_t == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityID = new SelectList(db.City_T, "CityID", "City", franchise_t.CityID);
            ViewBag.CountryID = new SelectList(db.Country_T, "CountryID", "Country", franchise_t.CountryID);
            return View(franchise_t);
        }

        //
        // POST: /Franchise/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Franchise_T franchise_t)
        {
            if (ModelState.IsValid)
            {
                db.Entry(franchise_t).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityID = new SelectList(db.City_T, "CityID", "City", franchise_t.CityID);
            ViewBag.CountryID = new SelectList(db.Country_T, "CountryID", "Country", franchise_t.CountryID);
            return View(franchise_t);
        }

        //
        // GET: /Franchise/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Franchise_T franchise_t = db.Franchise_T.Find(id);
            if (franchise_t == null)
            {
                return HttpNotFound();
            }
            return View(franchise_t);
        }

        //
        // POST: /Franchise/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Franchise_T franchise_t = db.Franchise_T.Find(id);
            db.Franchise_T.Remove(franchise_t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}