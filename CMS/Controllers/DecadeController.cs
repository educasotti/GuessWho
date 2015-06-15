using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository.Model;

namespace CMS.Controllers
{
    public class DecadeController : Controller
    {
        private GuessWhoContainer db = new GuessWhoContainer();

        //
        // GET: /Decade/

        public ActionResult Index()
        {
            return View(db.Decade.ToList());
        }

        //
        // GET: /Decade/Details/5

        public ActionResult Details(int id = 0)
        {
            Decade decade = db.Decade.Find(id);
            if (decade == null)
            {
                return HttpNotFound();
            }
            return View(decade);
        }

        //
        // GET: /Decade/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Decade/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Decade decade)
        {
            if (ModelState.IsValid)
            {
                db.Decade.Add(decade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(decade);
        }

        //
        // GET: /Decade/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Decade decade = db.Decade.Find(id);
            if (decade == null)
            {
                return HttpNotFound();
            }
            return View(decade);
        }

        //
        // POST: /Decade/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Decade decade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(decade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(decade);
        }

        //
        // GET: /Decade/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Decade decade = db.Decade.Find(id);
            if (decade == null)
            {
                return HttpNotFound();
            }
            return View(decade);
        }

        //
        // POST: /Decade/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Decade decade = db.Decade.Find(id);
            db.Decade.Remove(decade);
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