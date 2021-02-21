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
    public class TourController : Controller
    {
        private HikingGuanaDBEntities db = new HikingGuanaDBEntities();

        // GET: Tour
        public async Task<ActionResult> Index()
        {
            return View(await db.Tour.ToListAsync());
        }
        public ActionResult Index2()
        {
            return View( db.Tour.ToList());
        }
        public async Task<ActionResult> IndexAdmin()
        {
            return View(await db.Tour.ToListAsync());
        }

        // GET: Tour/Details/5
        public async Task<ActionResult> Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = await db.Tour.FindAsync(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // GET: Tour/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tour/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idTour,idTabladestinos,descripcion,lugarSalida,fechaCheckIn,fechaCheckOut,alimentacion,horaSalida,horaRegreso,precio,idGallery,nombreTour")] Tour tour, HttpPostedFileBase photo)
        {
            if (photo != null && photo.ContentLength > 0)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(photo.InputStream))
                {
                    imageData = binaryReader.ReadBytes(photo.ContentLength);
                }
                //setear la imagen a la entidad que se creara
                tour.photo = imageData;
            }

            if (ModelState.IsValid)
            {
                db.Tour.Add(tour);
                await db.SaveChangesAsync();
                return RedirectToAction("IndexAdmin");
            }

            return View(tour);
        }

        // GET: Tour/Edit/5
        public async Task<ActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = await db.Tour.FindAsync(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // POST: Tour/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idTour,idTabladestinos,descripcion,lugarSalida,fechaCheckIn,fechaCheckOut,alimentacion,horaSalida,horaRegreso,precio,idGallery,nombreTour")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tour).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tour);
        }

        // GET: Tour/Delete/5
        public async Task<ActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = await db.Tour.FindAsync(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // POST: Tour/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(short id)
        {
            Tour tour = await db.Tour.FindAsync(id);
            db.Tour.Remove(tour);
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

        public ActionResult convertirImagen(int idTour)
        {
            var photo = db.Tour.Where(z => z.idTour == idTour).FirstOrDefault();
            return File(photo.photo, "image/jpeg");
        }
    }
}
