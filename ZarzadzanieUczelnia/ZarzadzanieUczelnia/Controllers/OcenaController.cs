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
    public class OcenaController : Controller
    {
        private ZarzadzanieUczelniaContext db = new ZarzadzanieUczelniaContext();

        // GET: Ocena
        public ActionResult Index(long? Indeksy)
        {
            ViewBag.Indeksy = new SelectList(db.UczenSzkolies, "UzytkownikID", "Indeks",null);
            var ocenas = db.Ocenas.Include(o => o.Przedmiot).Include(o => o.Uczen);

            if (Indeksy != null)
            {
                var indeks = db.UczenSzkolies.Find(Indeksy).Indeks;
                ocenas = ocenas.Where(x => x.Uczen.Indeks == indeks);

            }
            return View(ocenas.ToList());
        }

        // GET: Ocena/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ocena ocena = db.Ocenas.Find(id);
            if (ocena == null)
            {
                return HttpNotFound();
            }
            return View(ocena);
        }

        // GET: Ocena/Create
        public ActionResult Create()
        {
            ViewBag.PrzedmiotID = new SelectList(db.Przedmiots, "PrzedmiotID", "Nazwa");
            ViewBag.UczenID = new SelectList(db.UczenSzkolies, "UzytkownikID", "Indeks");
            return View();
        }

        // POST: Ocena/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OcenaID,OtrzymanaOcena,Data,Komentarz,UczenID,PrzedmiotID")] Ocena ocena)
        {
            if (ModelState.IsValid)
            {
                db.Ocenas.Add(ocena);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PrzedmiotID = new SelectList(db.Przedmiots, "PrzedmiotID", "Nazwa", ocena.PrzedmiotID);
            ViewBag.UczenID = new SelectList(db.UczenSzkolies, "UzytkownikID", "Indeks", ocena.UczenID);
            return View(ocena);
        }

        // GET: Ocena/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ocena ocena = db.Ocenas.Find(id);
            if (ocena == null)
            {
                return HttpNotFound();
            }
            ViewBag.PrzedmiotID = new SelectList(db.Przedmiots, "PrzedmiotID", "Nazwa", ocena.PrzedmiotID);
            ViewBag.UczenID = new SelectList(db.UczenSzkolies, "UzytkownikID", "Indeks", ocena.UczenID);
            return View(ocena);
        }

        // POST: Ocena/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OcenaID,OtrzymanaOcena,Data,Komentarz,UczenID,PrzedmiotID")] Ocena ocena)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ocena).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PrzedmiotID = new SelectList(db.Przedmiots, "PrzedmiotID", "Nazwa", ocena.PrzedmiotID);
            ViewBag.UczenID = new SelectList(db.UczenSzkolies, "UzytkownikID", "Indeks", ocena.UczenID);
            return View(ocena);
        }

        // GET: Ocena/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ocena ocena = db.Ocenas.Find(id);
            if (ocena == null)
            {
                return HttpNotFound();
            }
            return View(ocena);
        }

        // POST: Ocena/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Ocena ocena = db.Ocenas.Find(id);
            db.Ocenas.Remove(ocena);
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
