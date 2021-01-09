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
using System.IO;

namespace Plantilla.Controllers
{
    public class TransporteController : Controller
    {
        private DB_A6C1FF_HikingGuanacasteEntities db = new DB_A6C1FF_HikingGuanacasteEntities();

        // GET: Transporte
        public async Task<ActionResult> Index()
        {
            return View(await db.Transporte.ToListAsync());
        }
        public async Task<ActionResult> IndexAdmin()
        {
            return View(await db.Transporte.ToListAsync());
        }

        // GET: Transporte/Details/5
        public async Task<ActionResult> Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transporte transporte = await db.Transporte.FindAsync(id);
            if (transporte == null)
            {
                return HttpNotFound();
            }
            return View(transporte);
        }

        // GET: Transporte/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transporte/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idTransporte,tipo,placa,marca,modelo,capacidad,color,colaboradorChofer,colaboradorResponsable")] Transporte transporte, HttpPostedFileBase foto)
        {
            if (foto != null && foto.ContentLength > 0)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(foto.InputStream))
                {
                    imageData = binaryReader.ReadBytes(foto.ContentLength);
                }
                //setear la imagen a la entidad que se creara
                transporte.foto = imageData;
            }
            if (ModelState.IsValid)
            {
                db.Transporte.Add(transporte);
                await db.SaveChangesAsync();
                return RedirectToAction("IndexAdmin");
            }

            return View(transporte);
        }

        // GET: Transporte/Edit/5
        public async Task<ActionResult> Edit(short? idTransporte)
        {
            if (idTransporte == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transporte transporte = await db.Transporte.FindAsync(idTransporte);
            if (transporte == null)
            {
                return HttpNotFound();
            }
            return View(transporte);
        }

        // POST: Transporte/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idTransporte,tipo,placa,marca,modelo,capacidad,color,colaboradorChofer,colaboradorResponsable")] Transporte transporte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transporte).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(transporte);
        }

        // GET: Transporte/Delete/5
        public async Task<ActionResult> Delete(short? idTransporte)
        {
            if (idTransporte == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transporte transporte = await db.Transporte.FindAsync(idTransporte);
            if (transporte == null)
            {
                return HttpNotFound();
            }
            return View(transporte);
        }

        // POST: Transporte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(short idTransporte)
        {
            Transporte transporte = await db.Transporte.FindAsync(idTransporte);
            db.Transporte.Remove(transporte);
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

        public ActionResult convertirImagen(int idTransporte)
        {
            var foto = db.Transporte.Where(z => z.idTransporte == idTransporte).FirstOrDefault();
            return File(foto.foto, "image/jpeg");
        }

    }
}
