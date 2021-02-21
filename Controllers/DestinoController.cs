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
    public class DestinoController : Controller
    {
        private HikingGuanaDBEntities db = new HikingGuanaDBEntities();

        // GET: Destino
        public async Task<ActionResult> Index()
        {
            return View(await db.Destino.ToListAsync());
        }
        public async Task<ActionResult> DestinysCard()
        {
            return View(await db.Destino.ToListAsync());
        }
        public async Task<ActionResult> IndexAdmin()
        {
            return View(await db.Destino.ToListAsync());
        }

        // GET: Destino/Details/5
        public async Task<ActionResult> Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destino destino = await db.Destino.FindAsync(id);
            if (destino == null)
            {
                return HttpNotFound();
            }
            return View(destino);
        }

        // GET: Destino/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Destino/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idDestino,tipoDestino,descripcion,idTablaActividades,idTablaAtracciones,coordenadas")] Destino destino)
        {
            if (ModelState.IsValid)
            {
                db.Destino.Add(destino);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(destino);
        }

        // GET: Destino/Edit/5
        public async Task<ActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destino destino = await db.Destino.FindAsync(id);
            if (destino == null)
            {
                return HttpNotFound();
            }
            return View(destino);
        }

        // POST: Destino/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idDestino,tipoDestino,descripcion,idTablaActividades,idTablaAtracciones,coordenadas")] Destino destino)
        {
            if (ModelState.IsValid)
            {
                db.Entry(destino).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(destino);
        }

        // GET: Destino/Delete/5
        public async Task<ActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destino destino = await db.Destino.FindAsync(id);
            if (destino == null)
            {
                return HttpNotFound();
            }
            return View(destino);
        }

        // POST: Destino/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(short id)
        {
            Destino destino = await db.Destino.FindAsync(id);
            db.Destino.Remove(destino);
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
