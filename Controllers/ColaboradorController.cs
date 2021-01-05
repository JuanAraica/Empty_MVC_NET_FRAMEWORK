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
using ImTools;
using System.Web.Helpers;

namespace Plantilla.Controllers
{
    public class ColaboradorController : Controller
    {
        private DB_A6C1FF_HikingGuanacasteEntities db = new DB_A6C1FF_HikingGuanacasteEntities();

        // GET: Colaborador
        public async Task<ActionResult> Index()
        {
            return View(await db.Colaborador.ToListAsync());
        }
 
        public String ObtenerImagen(int idColaborador)
        {
            String Stringimagen = db.Colaborador.Find(idColaborador).Image;
            if (Stringimagen!=null)
            {
                return Stringimagen;
            }
            return Stringimagen;
        }
        public async Task<ActionResult> IndexLogOut()
        {
            return View(await db.Colaborador.ToListAsync());
        }
        public async Task<ActionResult> IndexAdmin()
        {
            return View(await db.Colaborador.ToListAsync());
        }

        // GET: Colaborador/Details/5
        public async Task<ActionResult> Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colaborador colaborador = await db.Colaborador.FindAsync(id);
            if (colaborador == null)
            {
                return HttpNotFound();
            }
            return View(colaborador);
        }

        // GET: Colaborador/Create
        public ActionResult Create()
        {
            return View();
        }


        //public ActionResult convertirImagen(int idColaborador)
        //{
        //    var fotoP = db.Colaborador .Where(z => z.idColaborador == idColaborador).FirstOrDefault();
        //    return File(fotoP.fotoPerfil, "image/jpeg");
        //}


        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Nuevo(Colaborador oColaborador, HttpPostedFileBase fotoP)
        {
            if (ModelState.IsValid)
            {

                if (fotoP != null && fotoP.ContentLength > 0)
                {
                    byte[] imageData = null;
                    using (var binaryReader = new BinaryReader(fotoP.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(fotoP.ContentLength);
                    }
                    //setear la imagen a la entidad que se creara
                    oColaborador.fotoPerfil = imageData;
                }


                db.Colaborador.Add(oColaborador);
                db.SaveChanges();
                return View();
            }

            return View();
        }


        // POST: Colaborador/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idColaborador,CedColaborador,nombre,apellido1,apellido2,idiomas,nacionalidad,telefono,email,licencia,tipoColaborador")] Colaborador oColaborador, HttpPostedFileBase fotoPerfil)
        {
            if (fotoPerfil != null && fotoPerfil.ContentLength > 0)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(fotoPerfil.InputStream))
                {
                    imageData = binaryReader.ReadBytes(fotoPerfil.ContentLength);
                }
                //setear la imagen a la entidad que se creara
                oColaborador.fotoPerfil = imageData;
            }
            if (ModelState.IsValid)
            {
 
                db.Colaborador.Add(oColaborador);
                await db.SaveChangesAsync();
                return RedirectToAction("IndexAdmin");
            }

            return View(oColaborador);
        }

        // GET: Colaborador/Edit/5
        public async Task<ActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colaborador colaborador = await db.Colaborador.FindAsync(id);
            if (colaborador == null)
            {
                return HttpNotFound();
            }
            return View(colaborador);
        }

        // POST: Colaborador/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idColaborador,CedColaborador,nombre,apellido1,apellido2,idiomas,nacionalidad,telefono,email,licencia,tipoColaborador")] Colaborador colaborador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(colaborador).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(colaborador);
        }

        // GET: Colaborador/Delete/5
        public async Task<ActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colaborador colaborador = await db.Colaborador.FindAsync(id);
            if (colaborador == null)
            {
                return HttpNotFound();
            }
            return View(colaborador);
        }

        // POST: Colaborador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(short id)
        {
            Colaborador colaborador = await db.Colaborador.FindAsync(id);
            db.Colaborador.Remove(colaborador);
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


        public ActionResult convertirImagen(int idColaborador)
        {
            var fotoPerfil = db.Colaborador.Where(z => z.idColaborador == idColaborador).FirstOrDefault();
            return File(fotoPerfil.fotoPerfil, "image/jpeg");
        }



    }
}
