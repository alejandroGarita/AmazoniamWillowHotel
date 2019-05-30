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
          
            return View();
        }

        public JsonResult getAvailableDay()
        {
            var mo = new Models.Hotel_Amazonian_WillowEntities();

            return Json(mo.getRoomsDay(), JsonRequestBehavior.AllowGet);
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


        public ActionResult insertPromotionView()
        {

            return View();
        }

        public ActionResult updatePromotionView()
        {

            return View();
        }

        public ActionResult showPromotion()
        {
            using (var mo = new Models.Hotel_Amazonian_WillowEntities())
            {
      
                ViewData["Promotions"] = mo.Promocion.Include(p => p.Tipo_Habitacion).Include(p => p.Tipo_Habitacion.Imagen1).ToList();
            }
            return View();
        }

        public JsonResult getTypes()
        {
            var mo = new Models.Hotel_Amazonian_WillowEntities();

            return Json(mo.sp_getTypes(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult getPromotion()
        {
            var mo = new Models.Hotel_Amazonian_WillowEntities();
            return Json(mo.sp_getPromotions(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult getOnePromotion(int id)
        {
            var mo = new Models.Hotel_Amazonian_WillowEntities();
            return Json(mo.sp_getPromotion(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeletePromotion(int id)
        {
            var mo = new Models.Hotel_Amazonian_WillowEntities();
            mo.sp_deletePromotion(id);
            return Json("Eliminado", JsonRequestBehavior.AllowGet);
        }

        public JsonResult insertPromotion(string comment, int idescuento, DateTime iFechaInicio, DateTime iFechaFinal, int tipo) {

            if (comment != null && idescuento != 0 && tipo != 0
                && iFechaFinal != null && iFechaInicio != null)
            {
                var mo = new Models.Hotel_Amazonian_WillowEntities();

                mo.Promocion.Add(new Models.Promocion
                {
                    descripcion = comment,
                    descuento = idescuento,
                    inicio = iFechaInicio,
                    fin = iFechaFinal,
                    tipoHabitacion = tipo
                });
                mo.SaveChanges();
                return Json("OK", JsonRequestBehavior.AllowGet);
            }//end validation nulls

            return Json("ERROR", JsonRequestBehavior.AllowGet);

        }//end method

        public JsonResult updatePromotion(int id,string comment, int idescuento, DateTime iFechaInicio, DateTime iFechaFinal, int tipo)
        {

            if (comment != null && idescuento != 0 && tipo != 0
                && iFechaFinal != null && iFechaInicio != null)
            {
                var mo = new Models.Hotel_Amazonian_WillowEntities();
                var promo = mo.Promocion.Where(d => d.id == id).First();
                promo.id = id;
                promo.inicio = iFechaInicio;
                promo.descripcion = comment;
                promo.fin= iFechaFinal;
                promo.tipoHabitacion = tipo;
                promo.descuento = idescuento;

                mo.SaveChanges();
                return Json("OK", JsonRequestBehavior.AllowGet);
            }//end validation nulls

            return Json("ERROR", JsonRequestBehavior.AllowGet);

        }//end method

    }

}//end class