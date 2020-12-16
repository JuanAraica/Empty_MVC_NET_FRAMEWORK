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
    public class AtraccionController : Controller
    {
        private DB_A6C1FF_HikingGuanacasteEntities db = new DB_A6C1FF_HikingGuanacasteEntities();

        // GET: Atraccion
        public async Task<ActionResult> Index()
        {
            return View(await db.Atraccion.ToListAsync());
        }

        // GET: Atraccion/Details/5
        public async Task<ActionResult> Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atraccion atraccion = await db.Atraccion.FindAsync(id);
            if (atraccion == null)
            {
                return HttpNotFound();
            }
            return View(atraccion);
        }

        // GET: Atraccion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Atraccion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idAtraccion,nombre,descripcion,cantidadPersonas,inglumentaria,requisitos,precioTotalAtraccion")] Atraccion atraccion)
        {
            if (ModelState.IsValid)
            {
                db.Atraccion.Add(atraccion);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(atraccion);
        }

        // GET: Atraccion/Edit/5
        public async Task<ActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atraccion atraccion = await db.Atraccion.FindAsync(id);
            if (atraccion == null)
            {
                return HttpNotFound();
            }
            return View(atraccion);
        }

        // POST: Atraccion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idAtraccion,nombre,descripcion,cantidadPersonas,inglumentaria,requisitos,precioTotalAtraccion")] Atraccion atraccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atraccion).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(atraccion);
        }

        // GET: Atraccion/Delete/5
        public async Task<ActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atraccion atraccion = await db.Atraccion.FindAsync(id);
            if (atraccion == null)
            {
                return HttpNotFound();
            }
            return View(atraccion);
        }

        // POST: Atraccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(short id)
        {
            Atraccion atraccion = await db.Atraccion.FindAsync(id);
            db.Atraccion.Remove(atraccion);
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
