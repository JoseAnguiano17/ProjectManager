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
    public class ProyectoesController : Controller
    {
        private SystemContext db = new SystemContext();

        // GET: Proyectoes
        public ActionResult Index(int? id)
        {
            if (id != null) { Session["cliente"] = db.Clientes.Find(id); }
            else { Session["cliente"] = null; }
            return View(db.Proyectoes.ToList());
        }

        // GET: Proyectoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyecto proyecto = db.Proyectoes.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            return View(proyecto);
        }

        // GET: Proyectoes/Create
        public ActionResult Create(int? id)
        {
            Session["cliente"] = db.Clientes.Find(id);
            return View();
        }

        // POST: Proyectoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Descripcion,Costo,Estado,FechaCreacion")] Proyecto proyecto, [Bind(Include = "ClienteID")] int id)
        {
            if (ModelState.IsValid)
            {
                RedirectToRouteResult x = RedirectToAction("Index");
                Cliente cliente = db.Clientes.Find(id);
                db.Proyectoes.Add(proyecto);
                cliente.Proyectos.Add(proyecto);
                db.SaveChanges();
                x = RedirectToAction("Index", new { id = cliente.ID });
                return x;
            }

            return View(proyecto);
        }

        // GET: Proyectoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyecto proyecto = db.Proyectoes.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            return View(proyecto);
        }

        // POST: Proyectoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Descripcion,Costo,Estado,FechaCreacion")] Proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proyecto).State = EntityState.Modified;
                db.SaveChanges();
                var x = RedirectToAction("Index");
                Cliente cliente = (Cliente)Session["cliente"];
                if (cliente != null)
                    x = RedirectToAction("Index", new { id = cliente.ID });
                return x;
            }
            return View(proyecto);
        }

        // GET: Proyectoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyecto proyecto = db.Proyectoes.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            return View(proyecto);
        }

        // POST: Proyectoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proyecto proyecto = db.Proyectoes.Find(id);
            db.Proyectoes.Remove(proyecto);
            db.SaveChanges();
            var x = RedirectToAction("Index");
            Cliente cliente = (Cliente)Session["cliente"];
            if (cliente != null)
                x = RedirectToAction("Index", new { id = cliente.ID });
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
