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
    public class AdvertisementController : Controller
    {
        private BoomzGlobalEntities db = new BoomzGlobalEntities();

        //
        // GET: /Advertisement/

        public ActionResult Index()
        {
            var advertisement_t = db.Advertisement_T.Include(a => a.Company_T);
            return View(advertisement_t.ToList());
        }

        //
        // GET: /Advertisement/Details/5

        public ActionResult Details(int id = 0)
        {
            Advertisement_T advertisement_t = db.Advertisement_T.Find(id);
            if (advertisement_t == null)
            {
                return HttpNotFound();
            }
            return View(advertisement_t);
        }

        //
        // GET: /Advertisement/Create

        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.Company_T, "CompanyID", "CompanyName");
            return View();
        }

        //
        // POST: /Advertisement/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Advertisement_T advertisement_t)
        {
            if (ModelState.IsValid)
            {
                db.Advertisement_T.Add(advertisement_t);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.Company_T, "CompanyID", "CompanyName", advertisement_t.CompanyID);
            return View(advertisement_t);
        }

        //
        // GET: /Advertisement/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Advertisement_T advertisement_t = db.Advertisement_T.Find(id);
            if (advertisement_t == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.Company_T, "CompanyID", "CompanyName", advertisement_t.CompanyID);
            return View(advertisement_t);
        }

        //
        // POST: /Advertisement/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Advertisement_T advertisement_t)
        {
            if (ModelState.IsValid)
            {
                db.Entry(advertisement_t).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.Company_T, "CompanyID", "CompanyName", advertisement_t.CompanyID);
            return View(advertisement_t);
        }

        //
        // GET: /Advertisement/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Advertisement_T advertisement_t = db.Advertisement_T.Find(id);
            if (advertisement_t == null)
            {
                return HttpNotFound();
            }
            return View(advertisement_t);
        }

        //
        // POST: /Advertisement/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Advertisement_T advertisement_t = db.Advertisement_T.Find(id);
            db.Advertisement_T.Remove(advertisement_t);
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