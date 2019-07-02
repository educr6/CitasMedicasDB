using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalCitasMedicas.Controllers
{
    public class EspecialidadController : Controller
    {
        protected dbCitasMedicasEntities db = new dbCitasMedicasEntities();

        // GET: Especialidad
        public ActionResult Index()
        {
            var especialidades = getEspecialidades();
            return View(especialidades);
        }

        private IEnumerable<tblEspecialidad> getEspecialidades()
        {
            var especialidades = db.tblEspecialidads.SqlQuery("SELECT * FROM tblEspecialidad").ToList();
            return especialidades;
        }


        public ActionResult New()
        {

            return View("EspecialidadForm");
        }

        [HttpPost]
        public ActionResult Save(tblEspecialidad especialidad)
        {
            if (especialidad.idEspecialidad == 0)
            {
                db.Database.ExecuteSqlCommand("INSERT INTO tblEspecialidad VALUES " + "(@nombre)",
                    new SqlParameter("nombre", especialidad.nombreEspecialidad)
                    );
            }
            else
            {
                var laEspecialidad = db.tblEspecialidads.SqlQuery("SELECT * FROM tblEspecialidad WHERE idEspecialidad = " + especialidad.idEspecialidad).SingleOrDefault();
                laEspecialidad.nombreEspecialidad = especialidad.nombreEspecialidad;
            }

            db.SaveChanges();

            return RedirectToAction("Index", "Especialidad");
        }


        public ActionResult Edit(int? id)
        {
            var laEspecialidad = db.tblEspecialidads.SqlQuery("SELECT * FROM tblEspecialidad WHERE idEspecialidad = " + id).SingleOrDefault();

            if (laEspecialidad == null)
                return HttpNotFound();

            return View("EspecialidadForm", laEspecialidad);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            var elCentro = db.tblEspecialidads.SqlQuery("SELECT * FROM tblEspecialidad WHERE idEspecialidad = " + id).SingleOrDefault();

            if (elCentro == null)
            {
                return HttpNotFound();
            }
            return View(elCentro);
        }

        [HttpPost][ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {

            db.Database.ExecuteSqlCommand("DELETE FROM tblEspecialidad WHERE idEspecialidad = " + id);
            db.SaveChanges();

            return RedirectToAction("Index", "Especialidad");
        }

    }
}