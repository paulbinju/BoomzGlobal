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
    public class SubCategoryController : Controller
    {
        private BoomzGlobalEntities db = new BoomzGlobalEntities();

        //
        // GET: /SubCategory/

        public ActionResult Index()
        {
            ViewBag.CategoryID = new SelectList(db.Category_T, "CategoryID", "Category", "CategoryID");

            var subcategory_t = db.SubCategory_T.Include(s => s.Category_T);
            return View(subcategory_t.ToList());
        }

        //
        // GET: /SubCategory/Details/5

        public ActionResult Details(int id = 0)
        {
            SubCategory_T subcategory_t = db.SubCategory_T.Find(id);
            if (subcategory_t == null)
            {
                return HttpNotFound();
            }
            return View(subcategory_t);
        }

        //
        // GET: /SubCategory/Create

        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Category_T, "CategoryID", "Category");
            return View();
        }

        //
        // POST: /SubCategory/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubCategory_T subcategory_t)
        {
            if (ModelState.IsValid)
            {
                db.SubCategory_T.Add(subcategory_t);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Category_T, "CategoryID", "Category", subcategory_t.CategoryID);
            return View(subcategory_t);
        }

        //
        // GET: /SubCategory/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SubCategory_T subcategory_t = db.SubCategory_T.Find(id);
            if (subcategory_t == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Category_T, "CategoryID", "Category", subcategory_t.CategoryID);
            return View(subcategory_t);
        }

        //
        // POST: /SubCategory/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubCategory_T subcategory_t)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subcategory_t).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Category_T, "CategoryID", "Category", subcategory_t.CategoryID);
            return View(subcategory_t);
        }

        //
        // GET: /SubCategory/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SubCategory_T subcategory_t = db.SubCategory_T.Find(id);
            if (subcategory_t == null)
            {
                return HttpNotFound();
            }
            return View(subcategory_t);
        }

        //
        // POST: /SubCategory/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubCategory_T subcategory_t = db.SubCategory_T.Find(id);
            db.SubCategory_T.Remove(subcategory_t);
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