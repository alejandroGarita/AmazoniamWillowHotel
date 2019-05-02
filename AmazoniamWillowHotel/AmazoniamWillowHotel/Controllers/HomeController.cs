using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AmazoniamWillowHotel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Informate más de las atracciones que existen cerca del hotel";

            return View();
        }

        public ActionResult Login()
        {

            return View();
        }

        public ActionResult Contact()
        {
            using (var mo = new Models.Hotel_Amazonian_WillowEntities())
            {
                ViewData["Contact"] = mo.Pagina.ToList();
            }

            return View();
        }

        public ActionResult Facilities()
        {
            using (var mo = new Models.Hotel_Amazonian_WillowEntities()) {
                ViewData["Facilities"] = mo.Facilidad.ToList();
            }
            return View();
        }

        public ActionResult InsertFacilitie()
        {
            using (var mo = new Models.Hotel_Amazonian_WillowEntities())
            {
                ViewData["Status"] = new SelectList(mo.Estado.ToList(), "Id_Estado", "Nombre"); 
            }
            //ViewData["Status"] = new SelectList(model.getStatus(), "Id_Estado", "Nombre"); ;
            return View();
        }

        public ActionResult HowToGet()
        {
            return View();
        }

        public ActionResult Rates()
        {
            using (var mo = new Models.Hotel_Amazonian_WillowEntities())
            {
                ViewData["types"] = mo.Tipo_Habitacion.ToList();
            }
            return View();
        }
    }
}