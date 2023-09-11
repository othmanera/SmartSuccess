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
    public class ProfesseursController : Controller
    {
        private SmartSuccessEntities db = new SmartSuccessEntities();

        // GET: Professeurs
        public ActionResult Index()
        {
            return View(db.Professeurs.ToList());
        }

        // GET: Professeurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professeur professeur = db.Professeurs.Find(id);
            if (professeur == null)
            {
                return HttpNotFound();
            }
            return View(professeur);
        }

        // GET: Professeurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Professeurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Professeur,Nom,Prenom")] Professeur professeur)
        {
            if (ModelState.IsValid)
            {
                db.Professeurs.Add(professeur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(professeur);
        }

        // GET: Professeurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professeur professeur = db.Professeurs.Find(id);
            if (professeur == null)
            {
                return HttpNotFound();
            }
            return View(professeur);
        }

        // POST: Professeurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Professeur,Nom,Prenom")] Professeur professeur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(professeur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(professeur);
        }

        // GET: Professeurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professeur professeur = db.Professeurs.Find(id);
            if (professeur == null)
            {
                return HttpNotFound();
            }
            return View(professeur);
        }

        // POST: Professeurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Professeur professeur = db.Professeurs.Find(id);
            db.Professeurs.Remove(professeur);
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
