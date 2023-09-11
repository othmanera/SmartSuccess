using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SmartSuccess.Models;

namespace SmartSuccess.Controllers
{
    public class PaiementsController : Controller
    {
        private SmartSuccessEntities db = new SmartSuccessEntities();

        // GET: Paiements
        public ActionResult Index()
        {
            var paiements = db.Paiements.Include(p => p.Etudiant);
            return View(paiements.ToList());
        }

        // GET: Paiements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paiement paiement = db.Paiements.Find(id);
            if (paiement == null)
            {
                return HttpNotFound();
            }
            return View(paiement);
        }

        // GET: Paiements/Create
        public ActionResult Create()
        {
            ViewBag.ID_Etudiant = new SelectList(db.Etudiants, "ID_Etudiant", "Nom");
            return View();
        }

        // POST: Paiements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Paiement,Date_Paiement,Prix,Etat,ID_Etudiant")] Paiement paiement)
        {
            if (ModelState.IsValid)
            {
                db.Paiements.Add(paiement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Etudiant = new SelectList(db.Etudiants, "ID_Etudiant", "Nom", paiement.ID_Etudiant);
            return View(paiement);
        }

        // GET: Paiements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paiement paiement = db.Paiements.Find(id);
            if (paiement == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Etudiant = new SelectList(db.Etudiants, "ID_Etudiant", "Nom", paiement.ID_Etudiant);
            return View(paiement);
        }

        // POST: Paiements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Paiement,Date_Paiement,Prix,Etat,ID_Etudiant")] Paiement paiement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paiement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Etudiant = new SelectList(db.Etudiants, "ID_Etudiant", "Nom", paiement.ID_Etudiant);
            return View(paiement);
        }

        // GET: Paiements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paiement paiement = db.Paiements.Find(id);
            if (paiement == null)
            {
                return HttpNotFound();
            }
            return View(paiement);
        }

        // POST: Paiements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paiement paiement = db.Paiements.Find(id);
            db.Paiements.Remove(paiement);
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
