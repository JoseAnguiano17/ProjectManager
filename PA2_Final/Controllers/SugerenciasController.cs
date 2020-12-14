using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PA2_Final.DAL;
using PA2_Final.Models;

namespace PA2_Final.Controllers
{
    public class SugerenciasController : Controller
    {
        private SystemContext db = new SystemContext();

        // GET: Sugerencias
        public ActionResult Index(int? id)
        {
            if (id != null) { Session["proyecto"] = db.Proyectoes.Find(id); }
            else { Session["proyecto"] = null; }
            return View(db.Sugerencias.ToList());
        }

        // GET: Sugerencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sugerencia sugerencia = db.Sugerencias.Find(id);
            if (sugerencia == null)
            {
                return HttpNotFound();
            }
            return View(sugerencia);
        }

        // GET: Sugerencias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sugerencias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Descripcion,FechaCreacion,Estado")] Sugerencia sugerencia, [Bind(Include = "ProyectoID")] int id)
        {
            if (ModelState.IsValid)
            {
                RedirectToRouteResult x = RedirectToAction("Index");
                Proyecto proyecto = db.Proyectoes.Find(id);
                db.Sugerencias.Add(sugerencia);
                proyecto.Sugerencias.Add(sugerencia);
                db.SaveChanges();
                x = RedirectToAction("Index", new { id = proyecto.ID });
                return x;
            }

            return View(sugerencia);
        }

        // GET: Sugerencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sugerencia sugerencia = db.Sugerencias.Find(id);
            if (sugerencia == null)
            {
                return HttpNotFound();
            }
            return View(sugerencia);
        }

        // POST: Sugerencias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Descripcion,FechaCreacion,Estado")] Sugerencia sugerencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sugerencia).State = EntityState.Modified;
                db.SaveChanges();
                var x = RedirectToAction("Index");
                Proyecto proyecto = (Proyecto)Session["proyecto"];
                if (proyecto != null)
                    x = RedirectToAction("Index", new { id = proyecto.ID });
                return x;
            }
            return View(sugerencia);
        }

        // GET: Sugerencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sugerencia sugerencia = db.Sugerencias.Find(id);
            if (sugerencia == null)
            {
                return HttpNotFound();
            }
            return View(sugerencia);
        }

        // POST: Sugerencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sugerencia sugerencia = db.Sugerencias.Find(id);
            db.Sugerencias.Remove(sugerencia);
            db.SaveChanges();
            var x = RedirectToAction("Index");
            Proyecto proyecto = (Proyecto)Session["proyecto"];
            if (proyecto != null)
                x = RedirectToAction("Index", new { id = proyecto.ID });
            return x;
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
