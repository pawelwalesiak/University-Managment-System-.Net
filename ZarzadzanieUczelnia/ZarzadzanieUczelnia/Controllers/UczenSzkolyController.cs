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
    public class UczenSzkolyController : Controller
    {
        private ZarzadzanieUczelniaContext db = new ZarzadzanieUczelniaContext();

        // GET: UczenSzkoly
        public ActionResult Index()
        {
            var uczenSzkolies = db.UczenSzkolies.Include(u => u.Grupa);
            return View(uczenSzkolies.ToList());
        }

        // GET: UczenSzkoly/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UczenSzkoly uczenSzkoly = db.UczenSzkolies.Find(id);
            if (uczenSzkoly == null)
            {
                return HttpNotFound();
            }
            return View(uczenSzkoly);
        }

        // GET: UczenSzkoly/Create
        public ActionResult Create()
        {
            ViewBag.GrupaID = new SelectList(db.Grupas, "GrupaID", "Nazwa");
            return View();
        }

        // POST: UczenSzkoly/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UzytkownikID,Indeks,GrupaID,Imie,Nazwisko,DataUrodzenia")] UczenSzkoly uczenSzkoly)
        {
            if (ModelState.IsValid)
            {
                db.UczenSzkolies.Add(uczenSzkoly);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GrupaID = new SelectList(db.Grupas, "GrupaID", "Nazwa", uczenSzkoly.GrupaID);
            return View(uczenSzkoly);
        }

        // GET: UczenSzkoly/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UczenSzkoly uczenSzkoly = db.UczenSzkolies.Find(id);
            if (uczenSzkoly == null)
            {
                return HttpNotFound();
            }
            ViewBag.GrupaID = new SelectList(db.Grupas, "GrupaID", "Nazwa", uczenSzkoly.GrupaID);
            return View(uczenSzkoly);
        }

        // POST: UczenSzkoly/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UzytkownikID,Indeks,GrupaID,Imie,Nazwisko,DataUrodzenia")] UczenSzkoly uczenSzkoly)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uczenSzkoly).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GrupaID = new SelectList(db.Grupas, "GrupaID", "Nazwa", uczenSzkoly.GrupaID);
            return View(uczenSzkoly);
        }

        // GET: UczenSzkoly/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UczenSzkoly uczenSzkoly = db.UczenSzkolies.Find(id);
            if (uczenSzkoly == null)
            {
                return HttpNotFound();
            }
            return View(uczenSzkoly);
        }

        // POST: UczenSzkoly/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            UczenSzkoly uczenSzkoly = db.UczenSzkolies.Find(id);
            db.UczenSzkolies.Remove(uczenSzkoly);
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
