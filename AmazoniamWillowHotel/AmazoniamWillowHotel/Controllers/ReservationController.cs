using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.Data.Entity.Core.Objects;

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

        public ActionResult ReservationClient(int TipoHabitacion, String fechaLlegada, String fechaSalida)
        {
            using (var mo = new Models.Hotel_Amazonian_WillowEntities())
            {
                DateTime fechaLlegada1 = DateTime.Parse(fechaLlegada);
                DateTime fechaSalida1 = DateTime.Parse(fechaSalida);
                ObjectResult result = mo.CheckAvailability(TipoHabitacion, fechaLlegada1, fechaSalida1);
                re
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