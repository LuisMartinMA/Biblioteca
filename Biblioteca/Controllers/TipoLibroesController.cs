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
    public class TipoLibroesController : Controller
    {
        private BibliotecaContext db = new BibliotecaContext();

        // GET: TipoLibroes
        public ActionResult Index()
        {
            return View(db.TipoLibroes.ToList());
        }

        // GET: TipoLibroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoLibro tipoLibro = db.TipoLibroes.Find(id);
            if (tipoLibro == null)
            {
                return HttpNotFound();
            }
            return View(tipoLibro);
        }

        // GET: TipoLibroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoLibroes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GeneroID,DescripcionGenero")] TipoLibro tipoLibro)
        {
            if (ModelState.IsValid)
            {
                db.TipoLibroes.Add(tipoLibro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoLibro);
        }

        // GET: TipoLibroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoLibro tipoLibro = db.TipoLibroes.Find(id);
            if (tipoLibro == null)
            {
                return HttpNotFound();
            }
            return View(tipoLibro);
        }

        // POST: TipoLibroes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GeneroID,DescripcionGenero")] TipoLibro tipoLibro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoLibro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoLibro);
        }

        // GET: TipoLibroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoLibro tipoLibro = db.TipoLibroes.Find(id);
            if (tipoLibro == null)
            {
                return HttpNotFound();
            }
            return View(tipoLibro);
        }

        // POST: TipoLibroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoLibro tipoLibro = db.TipoLibroes.Find(id);
            db.TipoLibroes.Remove(tipoLibro);
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
