using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plantilla.Controllers
{
    public class VistasHtmlController : Controller
    {
        public ActionResult MainMenu()
        {
            return View();
        }
        public ActionResult SinLogin()
        {
            return View();
        }
        public ActionResult ReservForm()
        {
            return View();
        }
        public ActionResult HomeAdmin()
        {
            return View();
        }
    }
}