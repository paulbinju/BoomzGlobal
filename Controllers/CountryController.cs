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
    public class CountryController : Controller
    {
        private BoomzGlobalEntities db = new BoomzGlobalEntities();

        //
        // GET: /Country/

        public ActionResult Index()
        {
            return View(db.Country_T.ToList());
        }

        //
        // GET: /Country/Details/5

        public ActionResult Details(int id = 0)
        {
            Country_T country_t = db.Country_T.Find(id);
            if (country_t == null)
            {
                return HttpNotFound();
            }
            return View(country_t);
        }

        //
        // GET: /Country/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Country/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Country_T country_t)
        {
          
                db.Country_T.Add(country_t);
                db.SaveChanges();
                return RedirectToAction("Index");
             

           
        }

        //
        // GET: /Country/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Country_T country_t = db.Country_T.Find(id);
            if (country_t == null)
            {
                return HttpNotFound();
            }
            return View(country_t);
        }

        //
        // POST: /Country/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Country_T country_t)
        {
            
                db.Entry(country_t).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
             
           
        }

        //
        // GET: /Country/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Country_T country_t = db.Country_T.Find(id);
            if (country_t == null)
            {
                return HttpNotFound();
            }
            return View(country_t);
        }

        //
        // POST: /Country/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Country_T country_t = db.Country_T.Find(id);
            db.Country_T.Remove(country_t);
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