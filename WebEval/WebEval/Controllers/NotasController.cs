﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebEval.Models;

namespace WebEval.Controllers
{
    public class NotasController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Notas
        public ActionResult Index()
        {
            var notas = db.Notas.Include(n => n.Estudiante);
            return View(notas.ToList());
        }

        // GET: Notas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nota nota = db.Notas.Find(id);
            if (nota == null)
            {
                return HttpNotFound();
            }
            return View(nota);
        }

        // GET: Notas/Create
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Estudiantes, "StudentID", "Name");
            return View();
        }

        // POST: Notas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Calificacion,StudentID,estado,Materia")] Nota nota)
        {
            if (ModelState.IsValid)
            {
                db.Notas.Add(nota);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Estudiantes, "StudentID", "Name", nota.StudentID);
            return View(nota);
        }

        // GET: Notas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nota nota = db.Notas.Find(id);
            if (nota == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Estudiantes, "StudentID", "Name", nota.StudentID);
            return View(nota);
        }

        // POST: Notas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Calificacion,StudentID,estado,Materia")] Nota nota)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nota).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Estudiantes, "StudentID", "Name", nota.StudentID);
            return View(nota);
        }

        // GET: Notas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nota nota = db.Notas.Find(id);
            if (nota == null)
            {
                return HttpNotFound();
            }
            return View(nota);
        }

        // POST: Notas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nota nota = db.Notas.Find(id);
            db.Notas.Remove(nota);
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
