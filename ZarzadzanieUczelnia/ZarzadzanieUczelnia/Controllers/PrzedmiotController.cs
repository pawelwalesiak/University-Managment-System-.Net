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
    public class PrzedmiotController : Controller
    {
        private ZarzadzanieUczelniaContext db = new ZarzadzanieUczelniaContext();

        // GET: Przedmiot
        public ActionResult Index()
        {
            return View(db.Przedmiots.ToList());
        }

        // GET: Przedmiot/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Przedmiot przedmiot = db.Przedmiots.Find(id);
            if (przedmiot == null)
            {
                return HttpNotFound();
            }
            return View(przedmiot);
        }

        // GET: Przedmiot/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Przedmiot/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PrzedmiotID,Nazwa")] Przedmiot przedmiot)
        {
            if (ModelState.IsValid)
            {
                db.Przedmiots.Add(przedmiot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(przedmiot);
        }

        // GET: Przedmiot/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Przedmiot przedmiot = db.Przedmiots.Find(id);
            if (przedmiot == null)
            {
                return HttpNotFound();
            }
            return View(przedmiot);
        }

        // POST: Przedmiot/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PrzedmiotID,Nazwa")] Przedmiot przedmiot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(przedmiot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(przedmiot);
        }

        // GET: Przedmiot/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Przedmiot przedmiot = db.Przedmiots.Find(id);
            if (przedmiot == null)
            {
                return HttpNotFound();
            }
            return View(przedmiot);
        }

        // POST: Przedmiot/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Przedmiot przedmiot = db.Przedmiots.Find(id);
            db.Przedmiots.Remove(przedmiot);
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
