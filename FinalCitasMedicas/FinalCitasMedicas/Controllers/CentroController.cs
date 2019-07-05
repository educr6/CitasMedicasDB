using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalCitasMedicas.Controllers
{
    public class CentroController : Controller
    {
        protected dbCitasMedicasEntities1 db = new dbCitasMedicasEntities1();

        // GET: Centro
        public ActionResult Index()
        {
            ViewBag.isAdmin = TipoUsuarioElegido.isAdmin;
            var centros = getCentros();
            return View(centros);
        }

        private IEnumerable<tblCentroMedico> getCentros()
        {
            var centros = db.tblCentroMedicoes.SqlQuery("SELECT * FROM tblCentroMedico").ToList();
            return centros;
        }

        public ActionResult New()
        {

            return View("CentroForm");
        }

        [HttpPost]
        public ActionResult Save(tblCentroMedico centroMedico)
        {
            if (centroMedico.idCentroMedico == 0)
            {
                db.Database.ExecuteSqlCommand("INSERT INTO tblCentroMedico VALUES " +
                    "(@nombre, @telefono, @direccion, @paginaweb)",
                    new SqlParameter("nombre", centroMedico.nombreCentro),
                    new SqlParameter("telefono", centroMedico.telefonoCentro),
                    new SqlParameter("direccion", centroMedico.direccionCentro),
                    new SqlParameter("paginaweb", centroMedico.paginaWebCentro)
                    );
            }
            else
            {
                var elCentro = db.tblCentroMedicoes.SqlQuery("SELECT * FROM tblCentroMedico WHERE idCentroMedico = " + centroMedico.idCentroMedico).SingleOrDefault();
                elCentro.nombreCentro = centroMedico.nombreCentro;
                elCentro.telefonoCentro = centroMedico.telefonoCentro;
                elCentro.direccionCentro = centroMedico.direccionCentro;
                elCentro.paginaWebCentro = centroMedico.paginaWebCentro;
            }

            db.SaveChanges();

            return RedirectToAction("Index", "Centro");
        }

        public ActionResult Edit(int? id)
        {
            var elCentro = db.tblCentroMedicoes.SqlQuery("SELECT * FROM tblCentroMedico WHERE idCentroMedico = " + id).SingleOrDefault();

            if (elCentro == null)
                return HttpNotFound();

            return View("CentroForm", elCentro);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            var elCentro = db.tblCentroMedicoes.SqlQuery("SELECT * FROM tblCentroMedico WHERE idCentroMedico = " + id).SingleOrDefault();

            if (elCentro == null)
            {
                return HttpNotFound();
            }
            return View(elCentro);
        }

        [HttpPost][ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {

            db.Database.ExecuteSqlCommand("DELETE FROM tblCentroMedico WHERE idCentroMedico = " + id);
            db.SaveChanges();

            return RedirectToAction("Index", "Doctor");
        }



    }
}