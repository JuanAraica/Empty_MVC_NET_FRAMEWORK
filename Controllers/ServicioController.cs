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
    public class ServicioController : Controller
    {
        private DB_A6C1FF_HikingGuanacasteEntities db = new DB_A6C1FF_HikingGuanacasteEntities();

        // GET: Servicio
        public async Task<ActionResult> Index()
        {
            var servicio = db.Servicio.Include(s => s.Clientes).Include(s => s.Cupon).Include(s => s.GestionAdmin).Include(s => s.TablaAtracciones).Include(s => s.TablaActividades).Include(s => s.TablaDestinos).Include(s => s.Tour);
            return View(await servicio.ToListAsync());
        }

        // GET: Servicio/Details/5
        public async Task<ActionResult> Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicio servicio = await db.Servicio.FindAsync(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            return View(servicio);
        }

        // GET: Servicio/Create
        public ActionResult Create()
        {
            ViewBag.idCliente = new SelectList(db.Clientes, "idCliente", "email");
            ViewBag.idCupon = new SelectList(db.Cupon, "idCupon", "descripcion");
            ViewBag.idGestionAdmin = new SelectList(db.GestionAdmin, "idGestionAdmin", "idGestionAdmin");
            ViewBag.idTablaAtracciones = new SelectList(db.TablaAtracciones, "idTablaAtracciones", "descripcion");
            ViewBag.idTablaActividades = new SelectList(db.TablaActividades, "idTablaActividades", "descripcion");
            ViewBag.idTablaDestinos = new SelectList(db.TablaDestinos, "idTablaDestinos", "descripcion");
            ViewBag.idTablaToures = new SelectList(db.Tour, "idTour", "descripcion");
            return View();
        }

        // POST: Servicio/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idServicio,idCliente,idTablaAtracciones,idTablaToures,idCupon,idTablaDestinos,idTablaActividades,idGestionAdmin,descripcionServicio,precioTotalServicio,impuesto,comicion")] Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                db.Servicio.Add(servicio);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idCliente = new SelectList(db.Clientes, "idCliente", "email", servicio.idCliente);
            ViewBag.idCupon = new SelectList(db.Cupon, "idCupon", "descripcion", servicio.idCupon);
            ViewBag.idGestionAdmin = new SelectList(db.GestionAdmin, "idGestionAdmin", "idGestionAdmin", servicio.idGestionAdmin);
            ViewBag.idTablaAtracciones = new SelectList(db.TablaAtracciones, "idTablaAtracciones", "descripcion", servicio.idTablaAtracciones);
            ViewBag.idTablaActividades = new SelectList(db.TablaActividades, "idTablaActividades", "descripcion", servicio.idTablaActividades);
            ViewBag.idTablaDestinos = new SelectList(db.TablaDestinos, "idTablaDestinos", "descripcion", servicio.idTablaDestinos);
            ViewBag.idTablaToures = new SelectList(db.Tour, "idTour", "descripcion", servicio.idTablaToures);
            return View(servicio);
        }

        // GET: Servicio/Edit/5
        public async Task<ActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicio servicio = await db.Servicio.FindAsync(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCliente = new SelectList(db.Clientes, "idCliente", "email", servicio.idCliente);
            ViewBag.idCupon = new SelectList(db.Cupon, "idCupon", "descripcion", servicio.idCupon);
            ViewBag.idGestionAdmin = new SelectList(db.GestionAdmin, "idGestionAdmin", "idGestionAdmin", servicio.idGestionAdmin);
            ViewBag.idTablaAtracciones = new SelectList(db.TablaAtracciones, "idTablaAtracciones", "descripcion", servicio.idTablaAtracciones);
            ViewBag.idTablaActividades = new SelectList(db.TablaActividades, "idTablaActividades", "descripcion", servicio.idTablaActividades);
            ViewBag.idTablaDestinos = new SelectList(db.TablaDestinos, "idTablaDestinos", "descripcion", servicio.idTablaDestinos);
            ViewBag.idTablaToures = new SelectList(db.Tour, "idTour", "descripcion", servicio.idTablaToures);
            return View(servicio);
        }

        // POST: Servicio/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idServicio,idCliente,idTablaAtracciones,idTablaToures,idCupon,idTablaDestinos,idTablaActividades,idGestionAdmin,descripcionServicio,precioTotalServicio,impuesto,comicion")] Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicio).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idCliente = new SelectList(db.Clientes, "idCliente", "email", servicio.idCliente);
            ViewBag.idCupon = new SelectList(db.Cupon, "idCupon", "descripcion", servicio.idCupon);
            ViewBag.idGestionAdmin = new SelectList(db.GestionAdmin, "idGestionAdmin", "idGestionAdmin", servicio.idGestionAdmin);
            ViewBag.idTablaAtracciones = new SelectList(db.TablaAtracciones, "idTablaAtracciones", "descripcion", servicio.idTablaAtracciones);
            ViewBag.idTablaActividades = new SelectList(db.TablaActividades, "idTablaActividades", "descripcion", servicio.idTablaActividades);
            ViewBag.idTablaDestinos = new SelectList(db.TablaDestinos, "idTablaDestinos", "descripcion", servicio.idTablaDestinos);
            ViewBag.idTablaToures = new SelectList(db.Tour, "idTour", "descripcion", servicio.idTablaToures);
            return View(servicio);
        }

        // GET: Servicio/Delete/5
        public async Task<ActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicio servicio = await db.Servicio.FindAsync(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            return View(servicio);
        }

        // POST: Servicio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(short id)
        {
            Servicio servicio = await db.Servicio.FindAsync(id);
            db.Servicio.Remove(servicio);
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
