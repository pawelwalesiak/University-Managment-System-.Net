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
    public class GrupaController : Controller
    {
        private ZarzadzanieUczelniaContext db = new ZarzadzanieUczelniaContext();

        // GET: Grupa
        public ActionResult Index()
        {
            var grupas = db.Grupas.Include(g => g.Nauczyciel);
            return View(grupas.ToList());
        }

        // GET: Grupa/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupa grupa = db.Grupas.Find(id);
            if (grupa == null)
            {
                return HttpNotFound();
            }
            return View(grupa);
        }

        // GET: Grupa/Create
        public ActionResult Create()
        {
            ViewBag.NauczycielID = new SelectList(db.Nauczyciels, "UzytkownikID", "Imie");
            return View();
        }

        // POST: Grupa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GrupaID,Semestr,Nazwa,NauczycielID")] Grupa grupa)
        {
            if (ModelState.IsValid)
            {
                db.Grupas.Add(grupa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NauczycielID = new SelectList(db.Nauczyciels, "UzytkownikID", "Imie", grupa.NauczycielID);
            return View(grupa);
        }

        // GET: Grupa/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupa grupa = db.Grupas.Find(id);
            if (grupa == null)
            {
                return HttpNotFound();
            }
            ViewBag.NauczycielID = new SelectList(db.Nauczyciels, "UzytkownikID", "Imie", grupa.NauczycielID);
            return View(grupa);
        }

        // POST: Grupa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GrupaID,Semestr,Nazwa,NauczycielID")] Grupa grupa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NauczycielID = new SelectList(db.Nauczyciels, "UzytkownikID", "Imie", grupa.NauczycielID);
            return View(grupa);
        }

        // GET: Grupa/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupa grupa = db.Grupas.Find(id);
            if (grupa == null)
            {
                return HttpNotFound();
            }
            return View(grupa);
        }

        // POST: Grupa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Grupa grupa = db.Grupas.Find(id);
            db.Grupas.Remove(grupa);
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
