using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AmazoniamWillowHotel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            using (var mo = new Models.Hotel_Amazonian_WillowEntities())
            {
                ViewData["Home"] = mo.Pagina.Where(x => x.nombre == "Home").Include(p => p.Info).Include(p => p.Info.Select(x => x.Imagen1)).ToList();
                
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Informate más de las atracciones que existen cerca del hotel";

            using (var mo = new Models.Hotel_Amazonian_WillowEntities())
            {
                ViewData["SobreNosotros"] = mo.Pagina.Where(x => x.nombre == "Sobre Nosotros").Include(p => p.Info).Include(p => p.Info.Select(x => x.Imagen1)).ToList();
            }

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
                ViewData["Facilities"] = mo.Pagina.Where(x => x.nombre == "Facilidad");
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
            using (var mo = new Models.Hotel_Amazonian_WillowEntities())
            {
                ViewData["¿Como Llegar?"] = mo.Pagina.Where(x => x.nombre == "¿Como Llegar?").Include(p => p.Info).ToList();
            }
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