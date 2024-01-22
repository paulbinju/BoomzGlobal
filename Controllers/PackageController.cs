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
    public class PackageController : Controller
    {
        private BoomzGlobalEntities db = new BoomzGlobalEntities();

        //
        // GET: /Package/

        public ActionResult Index()
        {

            ViewBag.FranchiseID = new SelectList(db.Franchise_T, "FranchiseID", "FranchiseName", "FranchiseID");
            ViewBag.CityID = new SelectList(db.City_T, "CityID", "City", "CityID");


            var package_t = db.Package_T.Include(p => p.City_T).Include(p => p.Franchise_T);
            return View(package_t.ToList());
        }

        //
        // GET: /Package/Details/5

        public ActionResult Details(int id = 0)
        {
            Package_T package_t = db.Package_T.Find(id);
            if (package_t == null)
            {
                return HttpNotFound();
            }
            return View(package_t);
        }

        //
        // GET: /Package/Create

        public ActionResult Create()
        {
            ViewBag.CityID = new SelectList(db.City_T, "CityID", "City");
            ViewBag.FranchiseID = new SelectList(db.Franchise_T, "FranchiseID", "CompanyName");
            return View();
        }

        //
        // POST: /Package/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Package_T package_t)
        {
            if (ModelState.IsValid)
            {
                db.Package_T.Add(package_t);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityID = new SelectList(db.City_T, "CityID", "City", package_t.CityID);
            ViewBag.FranchiseID = new SelectList(db.Franchise_T, "FranchiseID", "CompanyName", package_t.FranchiseID);
            return View(package_t);
        }

        //
        // GET: /Package/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Package_T package_t = db.Package_T.Find(id);
            if (package_t == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityID = new SelectList(db.City_T, "CityID", "City", package_t.CityID);
            ViewBag.FranchiseID = new SelectList(db.Franchise_T, "FranchiseID", "CompanyName", package_t.FranchiseID);
            return View(package_t);
        }

        //
        // POST: /Package/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Package_T package_t)
        {
            if (ModelState.IsValid)
            {
                db.Entry(package_t).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityID = new SelectList(db.City_T, "CityID", "City", package_t.CityID);
            ViewBag.FranchiseID = new SelectList(db.Franchise_T, "FranchiseID", "CompanyName", package_t.FranchiseID);
            return View(package_t);
        }

        //
        // GET: /Package/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Package_T package_t = db.Package_T.Find(id);
            if (package_t == null)
            {
                return HttpNotFound();
            }
            return View(package_t);
        }

        //
        // POST: /Package/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Package_T package_t = db.Package_T.Find(id);
            db.Package_T.Remove(package_t);
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