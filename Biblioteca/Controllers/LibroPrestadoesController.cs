using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Biblioteca.Data;
using Biblioteca.Models;

namespace Biblioteca.Controllers
{
    public class LibroPrestadoesController : Controller
    {
        private BibliotecaContext db = new BibliotecaContext();

        // GET: LibroPrestadoes
        public ActionResult Index()
        {
            var libroPrestadoes = db.LibroPrestadoes.Include(l => l.Lector).Include(l => l.Libro);
            return View(libroPrestadoes.ToList());
        }

        // GET: LibroPrestadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibroPrestado libroPrestado = db.LibroPrestadoes.Find(id);
            if (libroPrestado == null)
            {
                return HttpNotFound();
            }
            return View(libroPrestado);
        }

        // GET: LibroPrestadoes/Create
        public ActionResult Create()
        {
            ViewBag.LectorID = new SelectList(db.Lectors, "LectorID", "Nombre");
            ViewBag.LibroID = new SelectList(db.Libros, "LibroID", "Nombre");
            return View();
        }

        // POST: LibroPrestadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PrestamoId,LectorID,LibroID")] LibroPrestado libroPrestado)
        {
            if (ModelState.IsValid)
            {
                db.LibroPrestadoes.Add(libroPrestado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LectorID = new SelectList(db.Lectors, "LectorID", "Nombre", libroPrestado.LectorID);
            ViewBag.LibroID = new SelectList(db.Libros, "LibroID", "Nombre", libroPrestado.LibroID);
            return View(libroPrestado);
        }

        // GET: LibroPrestadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibroPrestado libroPrestado = db.LibroPrestadoes.Find(id);
            if (libroPrestado == null)
            {
                return HttpNotFound();
            }
            ViewBag.LectorID = new SelectList(db.Lectors, "LectorID", "Nombre", libroPrestado.LectorID);
            ViewBag.LibroID = new SelectList(db.Libros, "LibroID", "Nombre", libroPrestado.LibroID);
            return View(libroPrestado);
        }

        // POST: LibroPrestadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PrestamoId,LectorID,LibroID")] LibroPrestado libroPrestado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libroPrestado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LectorID = new SelectList(db.Lectors, "LectorID", "Nombre", libroPrestado.LectorID);
            ViewBag.LibroID = new SelectList(db.Libros, "LibroID", "Nombre", libroPrestado.LibroID);
            return View(libroPrestado);
        }

        // GET: LibroPrestadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibroPrestado libroPrestado = db.LibroPrestadoes.Find(id);
            if (libroPrestado == null)
            {
                return HttpNotFound();
            }
            return View(libroPrestado);
        }

        // POST: LibroPrestadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LibroPrestado libroPrestado = db.LibroPrestadoes.Find(id);
            db.LibroPrestadoes.Remove(libroPrestado);
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
