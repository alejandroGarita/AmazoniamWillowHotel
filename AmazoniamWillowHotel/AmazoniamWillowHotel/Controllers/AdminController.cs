using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AmazoniamWillowHotel.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Login()
        {
            if (isNotLogin())
                return View();
            else return View("Index");
        }



        public ActionResult Index()
        {
            if (isNotLogin())
            { 
                if (Request.Form["username"] != null && Request.Form["password"] != null)
                {
                    String username = Request.Form["username"];
                    String password = Request.Form["password"];

                    using (var model = new Models.Hotel_Amazonian_WillowEntities())
                    {
                        if (model.Administrador.Where(x => x.correo == username && x.contrasenna == password).FirstOrDefault() != null)
                        {
                            Models.Administrador administrador = model.Administrador.Where(x => x.correo == username && x.contrasenna == password).FirstOrDefault();
                            Session["username"] = username;
                            Session["nombre"] = administrador.nombre;
                            return View();
                        }
                        else
                        {
                            ViewData["error"] = "Nombre de usuario o contraseña incorrecta";
                            return View("Login");
                        }
                    }
                }
                else
                {
                    ViewData["error"] = "Debe iniciar sesión";
                    return View("Login");
                }
            }
            return View();
        }

        public ActionResult Exit() {
            Session["username"] = null;
            return View("Login");
        }

        public bool isNotLogin() {
            if (Session["username"] != null)
                return false;
            return true;
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

        public ActionResult seeAvailableDay()
        {
          
            //ViewData["Status"] = new SelectList(model.getStatus(), "Id_Estado", "Nombre"); ;
            return View();
        }

        public JsonResult getAvailableDay()
        {
            var mo = new Models.Hotel_Amazonian_WillowEntities();

            return Json(mo.getRoomDay(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult CheckAvailability()
        {
            using (var mo = new Models.Hotel_Amazonian_WillowEntities())
            {
                ViewData["types"] = mo.Tipo_Habitacion.ToList();
            }
            return View();
        }

        public JsonResult consultarDisponibilidad(int TipoHabitacion, String fechaLlegada, String fechaSalida)
        {
            var mo = new Models.Hotel_Amazonian_WillowEntities();

            DateTime llegada = DateTime.Parse(fechaLlegada);
            DateTime salida = DateTime.Parse(fechaSalida);


            return Json(mo.CheckRoomsAvailable(llegada, salida, TipoHabitacion), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult modifyRoomType(int? type) {


            if (type != null)
            {
                var mo = new Models.Hotel_Amazonian_WillowEntities();
                ViewData["information"] = mo.Tipo_Habitacion.Where(x => x.id == type).Include(x => x.Imagen1).FirstOrDefault();
            }
            

            return View();
        }

    }


}