using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PA2_Final.DAL;
using PA2_Final.Models;

namespace PA2_Final
{
    public class ActualizacionesController : Controller
    {
        private SystemContext db = new SystemContext();

        // GET: Actualizaciones
        public ActionResult Index(int? id)
        {
            if (id != null) { Session["proyecto"] = db.Proyectoes.Find(id); }
            else { Session["proyecto"] = null; }
            return View(db.Actualizacions.ToList());
        }

        // GET: Actualizaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actualizacion actualizacion = db.Actualizacions.Find(id);
            if (actualizacion == null)
            {
                return HttpNotFound();
            }
            return View(actualizacion);
        }

        // GET: Actualizaciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Actualizaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Descripcion,FechaCreacion,Costo")] Actualizacion actualizacion, [Bind(Include = "ProyectoID")] int id)
        {
            if (ModelState.IsValid)
            {
                RedirectToRouteResult x = RedirectToAction("Index");
                Proyecto proyecto = db.Proyectoes.Find(id);
                db.Actualizacions.Add(actualizacion);
                proyecto.Actualizaciones.Add(actualizacion);
                db.SaveChanges();
                x = RedirectToAction("Index", new { id = proyecto.ID });
                return x;
            }

            return View(actualizacion);
        }

        // GET: Actualizaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actualizacion actualizacion = db.Actualizacions.Find(id);
            if (actualizacion == null)
            {
                return HttpNotFound();
            }
            return View(actualizacion);
        }

        // POST: Actualizaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Descripcion,FechaCreacion,Costo")] Actualizacion actualizacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actualizacion).State = EntityState.Modified;
                db.SaveChanges();
                var x = RedirectToAction("Index");
                Proyecto proyecto = (Proyecto)Session["proyecto"];
                if (proyecto != null)
                    x = RedirectToAction("Index", new { id = proyecto.ID });
                return x;
            }
            return View(actualizacion);
        }

        // GET: Actualizaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actualizacion actualizacion = db.Actualizacions.Find(id);
            if (actualizacion == null)
            {
                return HttpNotFound();
            }
            return View(actualizacion);
        }

        // POST: Actualizaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Actualizacion actualizacion = db.Actualizacions.Find(id);
            db.Actualizacions.Remove(actualizacion);
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
