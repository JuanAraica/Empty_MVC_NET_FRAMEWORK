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
    public class GalleryController : Controller
    {
        private DB_A6C1FF_HikingGuanacasteEntities db = new DB_A6C1FF_HikingGuanacasteEntities();

        // GET: Gallery
        public async Task<ActionResult> Index()
        {
            return View(await db.Gallery.ToListAsync());
        }

        // GET: Gallery/Details/5
        public async Task<ActionResult> Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery gallery = await db.Gallery.FindAsync(id);
            if (gallery == null)
            {
                return HttpNotFound();
            }
            return View(gallery);
        }

        // GET: Gallery/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gallery/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "descripcion")] Gallery gallery, HttpPostedFileBase image1, HttpPostedFileBase image2, HttpPostedFileBase image3,
            HttpPostedFileBase image4, HttpPostedFileBase image5, HttpPostedFileBase image6, HttpPostedFileBase image7, HttpPostedFileBase image8, HttpPostedFileBase image9)
        {
            byte[] imageData = null;
            if (image1 != null && image1.ContentLength > 0)
            {
                
                using (var binaryReader = new BinaryReader(image1.InputStream))
                {
                    imageData = binaryReader.ReadBytes(image1.ContentLength);
                }
                gallery.image1 = imageData;
            }
            else
            {
                db.Gallery.Add(gallery);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            if (image2 != null && image2.ContentLength > 0)
            {
 
                using (var binaryReader = new BinaryReader(image2.InputStream))
                {
                    imageData = binaryReader.ReadBytes(image2.ContentLength);
                }
                gallery.image2 = imageData;
            }
            else
            {
                db.Gallery.Add(gallery);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            if (image3 != null && image3.ContentLength > 0)
            {
 
                using (var binaryReader = new BinaryReader(image3.InputStream))
                {
                    imageData = binaryReader.ReadBytes(image3.ContentLength);
                }
                gallery.image3 = imageData;
            }
            else
            {
                db.Gallery.Add(gallery);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            if (image4 != null && image4.ContentLength > 0)
            {
 
                using (var binaryReader = new BinaryReader(image4.InputStream))
                {
                    imageData = binaryReader.ReadBytes(image4.ContentLength);
                }
                gallery.image4 = imageData;
            }
            else
            {
                db.Gallery.Add(gallery);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            if (image5 != null && image5.ContentLength > 0)
            {
 
                using (var binaryReader = new BinaryReader(image5.InputStream))
                {
                    imageData = binaryReader.ReadBytes(image5.ContentLength);
                }
                gallery.image5 = imageData;
            }
            else
            {
                db.Gallery.Add(gallery);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            if (image6 != null && image6.ContentLength > 0)
            {
 
                using (var binaryReader = new BinaryReader(image6.InputStream))
                {
                    imageData = binaryReader.ReadBytes(image6.ContentLength);
                }
                gallery.image6 = imageData;
            }
            else
            {
                db.Gallery.Add(gallery);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            if (image7 != null && image7.ContentLength > 0)
            {
 
                using (var binaryReader = new BinaryReader(image7.InputStream))
                {
                    imageData = binaryReader.ReadBytes(image7.ContentLength);
                }
                gallery.image7 = imageData;
            }
            else
            {
                db.Gallery.Add(gallery);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            if (image8 != null && image8.ContentLength > 0)
            {
 
                using (var binaryReader = new BinaryReader(image8.InputStream))
                {
                    imageData = binaryReader.ReadBytes(image8.ContentLength);
                }
                gallery.image8 = imageData;
            }
            else
            {
                db.Gallery.Add(gallery);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            if (image9 != null && image9.ContentLength > 0)
            {
 
                using (var binaryReader = new BinaryReader(image9.InputStream))
                {
                    imageData = binaryReader.ReadBytes(image9.ContentLength);
                }
                gallery.image9 = imageData;
            }
            if (ModelState.IsValid)
            {
                db.Gallery.Add(gallery);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(gallery);
        }

        // GET: Gallery/Edit/5
        public async Task<ActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery gallery = await db.Gallery.FindAsync(id);
            if (gallery == null)
            {
                return HttpNotFound();
            }
            return View(gallery);
        }

        // POST: Gallery/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idGallery,descripcion,image1,image2,image3,image4,image5,image6,image7,image8,image9")] Gallery gallery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gallery).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(gallery);
        }

        // GET: Gallery/Delete/5
        public async Task<ActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery gallery = await db.Gallery.FindAsync(id);
            if (gallery == null)
            {
                return HttpNotFound();
            }
            return View(gallery);
        }

        // POST: Gallery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(short id)
        {
            Gallery gallery = await db.Gallery.FindAsync(id);
            db.Gallery.Remove(gallery);
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


        public ActionResult convertirImagen(int idGallery)
        {
            var image1 = db.Gallery.Where(z => z.idGallery == idGallery).FirstOrDefault();
            if (image1 == null)
            {
                return View();
            }
            return File(image1.image1, "image/jpeg");
        }
        public ActionResult convertirImagen2(int idGallery)
        {
            var image2 = db.Gallery.Where(z => z.idGallery == idGallery).FirstOrDefault();
            if (image2 == null)
            {
                return View();
            }
            return File(image2.image2, "image/jpeg");
        }
        public ActionResult convertirImagen3(int idGallery)
        { 
            var image3 = db.Gallery.Where(z => z.idGallery == idGallery).FirstOrDefault();
            if (image3 == null)
            {
                return View();
            }
            return File(image3.image3, "image/jpeg");
        }
        public ActionResult convertirImagen4(int idGallery)
        {
            var image4 = db.Gallery.Where(z => z.idGallery == idGallery).FirstOrDefault();
            if (image4 == null)
            {
                return View();
            }
            return File(image4.image4, "image/jpeg");
        }
        public ActionResult convertirImagen5(int idGallery)
        {
            var image5 = db.Gallery.Where(z => z.idGallery == idGallery).FirstOrDefault();
            if (image5 == null)
            {
                return View();
            }
            return File(image5.image5, "image/jpeg");
        }
        public ActionResult convertirImagen6(int idGallery)
        {
            var image6 = db.Gallery.Where(z => z.idGallery == idGallery).FirstOrDefault();
            if (image6 == null)
            {
                return View();
            }
            return File(image6.image6, "image/jpeg");
        }
        public ActionResult convertirImagen7(int idGallery)
        {
            var image7 = db.Gallery.Where(z => z.idGallery == idGallery).FirstOrDefault();
            if (image7 == null)
            {
                return View();
            }
            return File(image7.image7, "image/jpeg");
        }
        public ActionResult convertirImagen8(int idGallery)
        {
            var image8 = db.Gallery.Where(z => z.idGallery == idGallery).FirstOrDefault();
            if (image8 == null)
            {
                return View();
            }
            return File(image8.image8, "image/jpeg");
        }
        public ActionResult convertirImagen9(int idGallery)
        {
            var image9 = db.Gallery.Where(z => z.idGallery == idGallery).FirstOrDefault();
            if (image9==null)
            {
                return View();
            }
            return File(image9.image9, "image/jpeg");
        }

    }
}
