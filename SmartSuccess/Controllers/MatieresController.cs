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
    public class MatieresController : Controller
    {
        private SmartSuccessEntities db = new SmartSuccessEntities();

        // GET: Matieres
        public ActionResult Index()
        {
            var matieres = db.Matieres.Include(m => m.Paiement).Include(m => m.Professeur);
            return View(matieres.ToList());
        }

        // GET: Matieres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matiere matiere = db.Matieres.Find(id);
            if (matiere == null)
            {
                return HttpNotFound();
            }
            return View(matiere);
        }

        // GET: Matieres/Create
        public ActionResult Create()
        {
            ViewBag.ID_Paiement = new SelectList(db.Paiements, "ID_Paiement", "Etat");
            ViewBag.ID_Professeur = new SelectList(db.Professeurs, "ID_Professeur", "Nom");
            return View();
        }

        // POST: Matieres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Matiere,Nom,Prix,ID_Paiement,ID_Professeur")] Matiere matiere)
        {
            if (ModelState.IsValid)
            {
                db.Matieres.Add(matiere);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Paiement = new SelectList(db.Paiements, "ID_Paiement", "Etat", matiere.ID_Paiement);
            ViewBag.ID_Professeur = new SelectList(db.Professeurs, "ID_Professeur", "Nom", matiere.ID_Professeur);
            return View(matiere);
        }

        // GET: Matieres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matiere matiere = db.Matieres.Find(id);
            if (matiere == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Paiement = new SelectList(db.Paiements, "ID_Paiement", "Etat", matiere.ID_Paiement);
            ViewBag.ID_Professeur = new SelectList(db.Professeurs, "ID_Professeur", "Nom", matiere.ID_Professeur);
            return View(matiere);
        }

        // POST: Matieres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Matiere,Nom,Prix,ID_Paiement,ID_Professeur")] Matiere matiere)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matiere).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Paiement = new SelectList(db.Paiements, "ID_Paiement", "Etat", matiere.ID_Paiement);
            ViewBag.ID_Professeur = new SelectList(db.Professeurs, "ID_Professeur", "Nom", matiere.ID_Professeur);
            return View(matiere);
        }

        // GET: Matieres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matiere matiere = db.Matieres.Find(id);
            if (matiere == null)
            {
                return HttpNotFound();
            }
            return View(matiere);
        }

        // POST: Matieres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Matiere matiere = db.Matieres.Find(id);
            db.Matieres.Remove(matiere);
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
