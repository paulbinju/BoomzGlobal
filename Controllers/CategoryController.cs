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
    public class CategoryController : Controller
    {
        private BoomzGlobalEntities db = new BoomzGlobalEntities();

        //
        // GET: /Category/

        public ActionResult Index()
        {
            return View(db.Category_T.ToList());
        }

        //
        // GET: /Category/Details/5

        public ActionResult Details(int id = 0)
        {
            Category_T category_t = db.Category_T.Find(id);
            if (category_t == null)
            {
                return HttpNotFound();
            }
            return View(category_t);
        }

        //
        // GET: /Category/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Category/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category_T category_t)
        {
            if (ModelState.IsValid)
            {
                db.Category_T.Add(category_t);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category_t);
        }

        //
        // GET: /Category/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Category_T category_t = db.Category_T.Find(id);
            if (category_t == null)
            {
                return HttpNotFound();
            }
            return View(category_t);
        }

        //
        // POST: /Category/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category_T category_t)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category_t).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category_t);
        }

        //
        // GET: /Category/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Category_T category_t = db.Category_T.Find(id);
            if (category_t == null)
            {
                return HttpNotFound();
            }
            return View(category_t);
        }

        //
        // POST: /Category/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category_T category_t = db.Category_T.Find(id);
            db.Category_T.Remove(category_t);
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