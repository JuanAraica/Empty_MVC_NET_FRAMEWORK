using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Plantilla.Models;

namespace Plantilla.Controllers
{
    public class ReferenciaController : Controller
    {
        private DB_A6C1FF_HikingGuanacasteEntities db = new DB_A6C1FF_HikingGuanacasteEntities();

        // GET: Referencia
        public async Task<ActionResult> Index()
        {
            return View(await db.Referencia.ToListAsync());
        }

        // GET: Referencia/Details/5
        public async Task<ActionResult> Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Referencia referencia = await db.Referencia.FindAsync(id);
            if (referencia == null)
            {
                return HttpNotFound();
            }
            return View(referencia);
        }

        // GET: Referencia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Referencia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idReferencia,idCliente,descipcion,calificacion")] Referencia referencia)
        {
            if (ModelState.IsValid)
            {
                db.Referencia.Add(referencia);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(referencia);
        }

        // GET: Referencia/Edit/5
        public async Task<ActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Referencia referencia = await db.Referencia.FindAsync(id);
            if (referencia == null)
            {
                return HttpNotFound();
            }
            return View(referencia);
        }

        // POST: Referencia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idReferencia,idCliente,descipcion,calificacion")] Referencia referencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(referencia).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(referencia);
        }

        // GET: Referencia/Delete/5
        public async Task<ActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Referencia referencia = await db.Referencia.FindAsync(id);
            if (referencia == null)
            {
                return HttpNotFound();
            }
            return View(referencia);
        }

        // POST: Referencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(short id)
        {
            Referencia referencia = await db.Referencia.FindAsync(id);
            db.Referencia.Remove(referencia);
            await db.SaveChangesAsync();
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
