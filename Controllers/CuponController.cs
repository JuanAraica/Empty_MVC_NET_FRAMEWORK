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
    public class CuponController : Controller
    {
        private DB_A6C1FF_HikingGuanacasteEntities db = new DB_A6C1FF_HikingGuanacasteEntities();

        // GET: Cupon
        public async Task<ActionResult> Index()
        {
            return View(await db.Cupon.ToListAsync());
        }

        // GET: Cupon/Details/5
        public async Task<ActionResult> Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cupon cupon = await db.Cupon.FindAsync(id);
            if (cupon == null)
            {
                return HttpNotFound();
            }
            return View(cupon);
        }

        // GET: Cupon/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cupon/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idCupon,descripcion,valor")] Cupon cupon)
        {
            if (ModelState.IsValid)
            {
                db.Cupon.Add(cupon);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cupon);
        }

        // GET: Cupon/Edit/5
        public async Task<ActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cupon cupon = await db.Cupon.FindAsync(id);
            if (cupon == null)
            {
                return HttpNotFound();
            }
            return View(cupon);
        }

        // POST: Cupon/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idCupon,descripcion,valor")] Cupon cupon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cupon).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cupon);
        }

        // GET: Cupon/Delete/5
        public async Task<ActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cupon cupon = await db.Cupon.FindAsync(id);
            if (cupon == null)
            {
                return HttpNotFound();
            }
            return View(cupon);
        }

        // POST: Cupon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(short id)
        {
            Cupon cupon = await db.Cupon.FindAsync(id);
            db.Cupon.Remove(cupon);
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
