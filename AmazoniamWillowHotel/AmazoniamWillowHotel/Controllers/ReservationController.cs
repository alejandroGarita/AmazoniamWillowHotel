using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;

namespace AmazoniamWillowHotel.Controllers
{
    public class ReservationController : Controller
    {

        public ActionResult OnlineBook()
        {
            using (var mo = new Models.Hotel_Amazonian_WillowEntities())
            {
                ViewData["types"] = mo.Tipo_Habitacion.ToList();
            }
            return View();
        }//OnlineBook

        public ActionResult ReservationClient(int TipoHabitacion, string fechaLlegada, string fechaSalida)
        {
            using (var mo = new Models.Hotel_Amazonian_WillowEntities())
            {
                return View(mo.Tipo_Habitacion.Find(TipoHabitacion));
            }
        }//ReservationClient

        public ActionResult ReservationInformation()
        {
            
            return View();
        }//ReservationInformation

        public JsonResult process()
        {
            Thread.Sleep(3000);
            return Json("Procesado", JsonRequestBehavior.AllowGet);
        }//process
        
    }
}