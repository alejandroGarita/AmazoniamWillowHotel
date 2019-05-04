using System;
using System.Collections.Generic;
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
                        if (model.Administrador.Where(x => x.Correo == username && x.Contrasena == password).FirstOrDefault() != null)
                        {
                            Session["username"] = username;
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

    }
}