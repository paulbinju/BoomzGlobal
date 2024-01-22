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
    public class CityController : Controller
    {
        private BoomzGlobalEntities db = new BoomzGlobalEntities();

        //
        // GET: /City/

        public ActionResult Index()
        {
            ViewBag.CountryID = new SelectList(db.Country_T, "CountryID", "Country", "CountryID");


            var city_t = db.City_T.Include(c => c.Country_T);
            return View(city_t.ToList());
        }

        //
        // GET: /City/Details/5

        public ActionResult Details(int id = 0)
        {
            City_T city_t = db.City_T.Find(id);
            if (city_t == null)
            {
                return HttpNotFound();
            }
            return View(city_t);
        }

        //
        // GET: /City/Create

        public ActionResult Create()
        {
            
            return View();
        }

        //
        // POST: /City/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(City_T city_t)
        {
            if (ModelState.IsValid)
            {
                db.City_T.Add(city_t);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryID = new SelectList(db.Country_T, "CountryID", "Country", city_t.CountryID);
            return View(city_t);
        }

        //
        // GET: /City/Edit/5

        public ActionResult Edit(int id = 0)
        {
            City_T city_t = db.City_T.Find(id);
            if (city_t == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryID = new SelectList(db.Country_T, "CountryID", "Country", city_t.CountryID);
            return View(city_t);
        }

        //
        // POST: /City/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(City_T city_t)
        {
            if (ModelState.IsValid)
            {
                db.Entry(city_t).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryID = new SelectList(db.Country_T, "CountryID", "Country", city_t.CountryID);
            return View(city_t);
        }

        //
        // GET: /City/Delete/5

        public ActionResult Delete(int id = 0)
        {
            City_T city_t = db.City_T.Find(id);
            if (city_t == null)
            {
                return HttpNotFound();
            }
            return View(city_t);
        }

        //
        // POST: /City/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            City_T city_t = db.City_T.Find(id);
            db.City_T.Remove(city_t);
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