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
    public class CompanyController : Controller
    {
        private BoomzGlobalEntities db = new BoomzGlobalEntities();

        //
        // GET: /Company/

        public ActionResult Index()
        {
            var company_t = db.Company_T.Include(c => c.Category_T).Include(c => c.City_T).Include(c => c.Country_T).Include(c => c.SubCategory_T);
            return View(company_t.ToList());
        }

        //
        // GET: /Company/Details/5

        public ActionResult Details(int id = 0)
        {
            Company_T company_t = db.Company_T.Find(id);
            if (company_t == null)
            {
                return HttpNotFound();
            }
            return View(company_t);
        }

        //
        // GET: /Company/Create

        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Category_T, "CategoryID", "Category");
            ViewBag.CityID = new SelectList(db.City_T, "CityID", "City");
            ViewBag.CountryID = new SelectList(db.Country_T, "CountryID", "Country");
            ViewBag.SubCategoryID = new SelectList(db.SubCategory_T, "SubCategoryID", "SubCategory");
            return View();
        }

        //
        // POST: /Company/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Company_T company_t)
        {
            if (ModelState.IsValid)
            {
                db.Company_T.Add(company_t);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Category_T, "CategoryID", "Category", company_t.CategoryID);
            ViewBag.CityID = new SelectList(db.City_T, "CityID", "City", company_t.CityID);
            ViewBag.CountryID = new SelectList(db.Country_T, "CountryID", "Country", company_t.CountryID);
            ViewBag.SubCategoryID = new SelectList(db.SubCategory_T, "SubCategoryID", "SubCategory", company_t.SubCategoryID);
            return View(company_t);
        }

        //
        // GET: /Company/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Company_T company_t = db.Company_T.Find(id);
            if (company_t == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Category_T, "CategoryID", "Category", company_t.CategoryID);
            ViewBag.CityID = new SelectList(db.City_T, "CityID", "City", company_t.CityID);
            ViewBag.CountryID = new SelectList(db.Country_T, "CountryID", "Country", company_t.CountryID);
            ViewBag.SubCategoryID = new SelectList(db.SubCategory_T, "SubCategoryID", "SubCategory", company_t.SubCategoryID);
            return View(company_t);
        }

        //
        // POST: /Company/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Company_T company_t)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company_t).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Category_T, "CategoryID", "Category", company_t.CategoryID);
            ViewBag.CityID = new SelectList(db.City_T, "CityID", "City", company_t.CityID);
            ViewBag.CountryID = new SelectList(db.Country_T, "CountryID", "Country", company_t.CountryID);
            ViewBag.SubCategoryID = new SelectList(db.SubCategory_T, "SubCategoryID", "SubCategory", company_t.SubCategoryID);
            return View(company_t);
        }

        //
        // GET: /Company/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Company_T company_t = db.Company_T.Find(id);
            if (company_t == null)
            {
                return HttpNotFound();
            }
            return View(company_t);
        }

        //
        // POST: /Company/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company_T company_t = db.Company_T.Find(id);
            db.Company_T.Remove(company_t);
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