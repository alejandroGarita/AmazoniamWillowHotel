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

        public ActionResult ReservationClient(int numero, String titulo, String descripcion, double tarifa, String imagen, String fechaLlegada, String fechaSalida)
        {
            Models.CheckAvailability_Result checkAvailability = new Models.CheckAvailability_Result();

            checkAvailability.numero = numero;
            checkAvailability.titulo = titulo;
            checkAvailability.descripcion = descripcion;
            checkAvailability.tarifa = tarifa;
            checkAvailability.imagen = imagen;
            ViewData["fechaLlegada"] = fechaLlegada;
            ViewData["fechaSalida"] = fechaSalida;
            return View(checkAvailability);
        }//ReservationClient

        public ActionResult ReservationInformation(String nombreCompleto, String correo_, int numeroReserva)
        {
            Models.MakeReservation_Result makeReservation = new Models.MakeReservation_Result();

            makeReservation.nombre = nombreCompleto;
            makeReservation.correo = correo_;
            makeReservation.numeroReserva = numeroReserva;

            return View(makeReservation);
        }//ReservationInformation

        public JsonResult checkAvailability(int TipoHabitacion, String fechaLlegada, String fechaSalida)
        {
            using (var mo = new Models.Hotel_Amazonian_WillowEntities())
            {
                DateTime fechaLlegada1 = DateTime.Parse(fechaLlegada);
                DateTime fechaSalida1 = DateTime.Parse(fechaSalida);
                ObjectResult<Models.CheckAvailability_Result> result = mo.CheckAvailability(TipoHabitacion, fechaLlegada1, fechaSalida1);

                Models.CheckAvailability_Result checkAvailability1 = new Models.CheckAvailability_Result();
                foreach (Models.CheckAvailability_Result checkAvailability in result)
                    checkAvailability1 = checkAvailability;

                Thread.Sleep(3000);
                return Json(checkAvailability1, JsonRequestBehavior.AllowGet);
            }
        }//checkAvailability

        public JsonResult makeReservation(String identificacion, String nombre, String apellidos, String correo, String tarjeta, int numero, String fechaLlegada, String fechaSalida)
        {
            using (var mo = new Models.Hotel_Amazonian_WillowEntities())
            {
                DateTime fechaLlegada1 = DateTime.Parse(fechaLlegada);
                DateTime fechaSalida1 = DateTime.Parse(fechaSalida);
                ObjectResult<Models.MakeReservation_Result> result = mo.MakeReservation(identificacion, nombre, apellidos, correo, tarjeta, numero, fechaLlegada1, fechaSalida1);

                Models.MakeReservation_Result makeReservation1 = new Models.MakeReservation_Result();
                foreach (Models.MakeReservation_Result makeReservation in result)
                    makeReservation1 = makeReservation;

                Thread.Sleep(3000);
                return Json(makeReservation1, JsonRequestBehavior.AllowGet);
            }
        }//makeReservation

        public JsonResult freeRoom(int numero)
        {
            using (var mo = new Models.Hotel_Amazonian_WillowEntities())
            {
                mo.FreeRoom(numero);
                
                return Json("Cancelado", JsonRequestBehavior.AllowGet);
            }
        }//freeRoom
    }
}