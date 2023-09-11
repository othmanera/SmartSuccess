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
    public class EtudiantsController : Controller
    {
        private SmartSuccessEntities db = new SmartSuccessEntities();

        // GET: Etudiants
        public ActionResult Index()
        {
            var etudiants = db.Etudiants.Include(e => e.Niveau);
            return View(etudiants.ToList());
        }

        // GET: Etudiants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etudiant etudiant = db.Etudiants.Find(id);
            if (etudiant == null)
            {
                return HttpNotFound();
            }
            return View(etudiant);
        }

        // GET: Etudiants/Create
        public ActionResult Create()
        {
            ViewBag.ID_Niveau = new SelectList(db.Niveaux, "ID_Niveau", "Nom");
            return View();
        }

        // POST: Etudiants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Etudiant,Nom,Prenom,ID_Niveau,Date_Inscription")] Etudiant etudiant)
        {
            if (ModelState.IsValid)
            {
                db.Etudiants.Add(etudiant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Niveau = new SelectList(db.Niveaux, "ID_Niveau", "Nom", etudiant.ID_Niveau);
            return View(etudiant);
        }

        // GET: Etudiants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etudiant etudiant = db.Etudiants.Find(id);
            if (etudiant == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Niveau = new SelectList(db.Niveaux, "ID_Niveau", "Nom", etudiant.ID_Niveau);
            return View(etudiant);
        }

        // POST: Etudiants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Etudiant,Nom,Prenom,ID_Niveau,Date_Inscription")] Etudiant etudiant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(etudiant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Niveau = new SelectList(db.Niveaux, "ID_Niveau", "Nom", etudiant.ID_Niveau);
            return View(etudiant);
        }

        // GET: Etudiants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etudiant etudiant = db.Etudiants.Find(id);
            if (etudiant == null)
            {
                return HttpNotFound();
            }
            return View(etudiant);
        }

        // POST: Etudiants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Etudiant etudiant = db.Etudiants.Find(id);
            db.Etudiants.Remove(etudiant);
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
