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
                ObjectResult<Models.CheckAvailability_Result> result = mo.CheckAvailability(TipoHabitacion, fechaLlegada1, fechaSalida1);

                Models.CheckAvailability_Result checkAvailability1 = new Models.CheckAvailability_Result();
                foreach (Models.CheckAvailability_Result checkAvailability in result)
                    checkAvailability1 = checkAvailability;

                return View(checkAvailability1);
            }
        }//ReservationClient

        public ActionResult ReservationInformation()
        {
            
            return View();
        }//ReservationInformation

        public JsonResult checkAvailability()
        {
            Thread.Sleep(3000);
            return Json("Procesado", JsonRequestBehavior.AllowGet);
        }//process

        public JsonResult process()
        {
            Thread.Sleep(3000);
            return Json("Procesado", JsonRequestBehavior.AllowGet);
        }//process
        
    }
}