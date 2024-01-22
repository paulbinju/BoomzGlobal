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
    public class CompanyPackageController : Controller
    {
        private BoomzGlobalEntities db = new BoomzGlobalEntities();

        //
        // GET: /CompanyPackage/

        public ActionResult Index()
        {
            var company_package_t = db.Company_Package_T.Include(c => c.Company_T).Include(c => c.Franchise_T);
            return View(company_package_t.ToList());
        }

        //
        // GET: /CompanyPackage/Details/5

        public ActionResult Details(int id = 0)
        {
            Company_Package_T company_package_t = db.Company_Package_T.Find(id);
            if (company_package_t == null)
            {
                return HttpNotFound();
            }
            return View(company_package_t);
        }

        //
        // GET: /CompanyPackage/Create

        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.Company_T, "CompanyID", "CompanyName");
            ViewBag.FranchiseID = new SelectList(db.Franchise_T, "FranchiseID", "CompanyName");
            return View();
        }

        //
        // POST: /CompanyPackage/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Company_Package_T company_package_t)
        {
            if (ModelState.IsValid)
            {
                db.Company_Package_T.Add(company_package_t);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.Company_T, "CompanyID", "CompanyName", company_package_t.CompanyID);
            ViewBag.FranchiseID = new SelectList(db.Franchise_T, "FranchiseID", "CompanyName", company_package_t.FranchiseID);
            return View(company_package_t);
        }

        //
        // GET: /CompanyPackage/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Company_Package_T company_package_t = db.Company_Package_T.Find(id);
            if (company_package_t == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.Company_T, "CompanyID", "CompanyName", company_package_t.CompanyID);
            ViewBag.FranchiseID = new SelectList(db.Franchise_T, "FranchiseID", "CompanyName", company_package_t.FranchiseID);
            return View(company_package_t);
        }

        //
        // POST: /CompanyPackage/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Company_Package_T company_package_t)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company_package_t).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.Company_T, "CompanyID", "CompanyName", company_package_t.CompanyID);
            ViewBag.FranchiseID = new SelectList(db.Franchise_T, "FranchiseID", "CompanyName", company_package_t.FranchiseID);
            return View(company_package_t);
        }

        //
        // GET: /CompanyPackage/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Company_Package_T company_package_t = db.Company_Package_T.Find(id);
            if (company_package_t == null)
            {
                return HttpNotFound();
            }
            return View(company_package_t);
        }

        //
        // POST: /CompanyPackage/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company_Package_T company_package_t = db.Company_Package_T.Find(id);
            db.Company_Package_T.Remove(company_package_t);
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