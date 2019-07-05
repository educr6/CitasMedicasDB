using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalCitasMedicas.ViewModel;

namespace FinalCitasMedicas.Controllers
{
    public class UserTypeController : Controller
    {
        // GET: UserType
        public ActionResult Index()
        {
            var usuariovm = new TipoUsuarioViewModel();
            if (TipoUsuarioElegido.isAdmin)
            {
                usuariovm.tipoDeUsuario = "admin";
            } else
            {
                usuariovm.tipoDeUsuario = "paciente";
            }



            return View(usuariovm);
        }

        public ActionResult setAdmin()
        {
            TipoUsuarioElegido.isAdmin = true;
            return View("Index", new TipoUsuarioViewModel() { tipoDeUsuario = "admin" });
        }

        public ActionResult setPatient()
        {
            TipoUsuarioElegido.isAdmin = false;
            return View("Index", new TipoUsuarioViewModel() { tipoDeUsuario = "paciente" });
        }
    }

    public static class TipoUsuarioElegido
    {
        public static bool isAdmin = true;

        
    }
}