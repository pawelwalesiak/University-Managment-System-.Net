using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZarzadzanieUczelnia.DAL;
using ZarzadzanieUczelnia.Models;

namespace ZarzadzanieUczelnia.Controllers
{
    public class NauczycielController : Controller
    {
        private ZarzadzanieUczelniaContext db = new ZarzadzanieUczelniaContext();

        // GET: Nauczyciel
        public ActionResult Index()
        {
            return View(db.Nauczyciels.ToList());
        }

        // GET: Nauczyciel/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nauczyciel nauczyciel = db.Nauczyciels.Find(id);
            if (nauczyciel == null)
            {
                return HttpNotFound();
            }
            return View(nauczyciel);
        }

        // GET: Nauczyciel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nauczyciel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UzytkownikID,Imie,Nazwisko,DataUrodzenia")] Nauczyciel nauczyciel)
        {
            if (ModelState.IsValid)
            {
                db.Nauczyciels.Add(nauczyciel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nauczyciel);
        }

        // GET: Nauczyciel/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nauczyciel nauczyciel = db.Nauczyciels.Find(id);
            if (nauczyciel == null)
            {
                return HttpNotFound();
            }
            return View(nauczyciel);
        }

        // POST: Nauczyciel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UzytkownikID,Imie,Nazwisko,DataUrodzenia")] Nauczyciel nauczyciel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nauczyciel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nauczyciel);
        }

        // GET: Nauczyciel/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nauczyciel nauczyciel = db.Nauczyciels.Find(id);
            if (nauczyciel == null)
            {
                return HttpNotFound();
            }
            return View(nauczyciel);
        }

        // POST: Nauczyciel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Nauczyciel nauczyciel = db.Nauczyciels.Find(id);
            db.Nauczyciels.Remove(nauczyciel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
