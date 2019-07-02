using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalCitasMedicas.ViewModel;

namespace FinalCitasMedicas.Controllers
{
    public class DoctorController : Controller
    {
        protected dbCitasMedicasEntities db = new dbCitasMedicasEntities();

        // GET: Doctor
        public ActionResult Index()
        {
            var doctores = db.tblDoctors.SqlQuery("SELECT * FROM tblDoctor").ToList();
            var doctorsList = new List<DoctorViewModel>();


            for (int i = 0; i < doctores.Count(); i++)
            {
                doctorsList.Add(
                    new DoctorViewModel()
                    {
                        doctor = doctores[i],
                        especialidad = db.tblEspecialidads.SqlQuery("SELECT * FROM tblEspecialidad WHERE idEspecialidad = " + doctores[i].idEspecialidad).FirstOrDefault()
                    }
                );
            }



            return View(doctorsList);
        }

        public ActionResult Details(int id)
        {
            var doctorX = db.tblDoctors.SqlQuery("SELECT * FROM tblDoctor WHERE idDoctor = " + id).FirstOrDefault();
            var especialidadX = db.tblEspecialidads.SqlQuery("SELECT * FROM tblEspecialidad WHERE idEspecialidad = " + doctorX.idDoctor).FirstOrDefault();

            return View(new DoctorViewModel() { doctor = doctorX, especialidad = especialidadX });
        }

        public ActionResult New()
        {

            var especialidades = db.tblEspecialidads.SqlQuery("SELECT * FROM tblEspecialidad").ToList();
            var viewModel = new DoctorViewModel
            {
                listaEspecialidad = especialidades
            };

            return View("DoctorForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(tblDoctor Doctor)
        {
            if (Doctor.idDoctor == 0)
            {
                db.Database.ExecuteSqlCommand("INSERT INTO tblDoctor VALUES " +
                    "(@idEspecialidad, @nombre, @cedula, @fechanacimiento, @correo, @telefono, @direccion)",
                    new SqlParameter("idEspecialidad", Doctor.idEspecialidad),
                    new SqlParameter("nombre", Doctor.nombreDoctor),
                    new SqlParameter("cedula", Doctor.cedulaDoctor),
                    new SqlParameter("fechanacimiento", Doctor.fechaNacimientoDoctor),
                    new SqlParameter("correo", Doctor.correoDoctor),
                    new SqlParameter("telefono", Doctor.telefonoDoctor),
                    new SqlParameter("direccion", Doctor.direccionDoctor)
                    );
            }
            else
            {
                var elDoctor = db.tblDoctors.SqlQuery("SELECT * FROM tblDoctor WHERE idDoctor = " + Doctor.idDoctor).SingleOrDefault();
                elDoctor.nombreDoctor = Doctor.nombreDoctor;
                elDoctor.cedulaDoctor = Doctor.cedulaDoctor;
                elDoctor.fechaNacimientoDoctor = Doctor.fechaNacimientoDoctor;
                elDoctor.correoDoctor = Doctor.correoDoctor;
                elDoctor.telefonoDoctor = Doctor.telefonoDoctor;
                elDoctor.direccionDoctor = Doctor.direccionDoctor;
                elDoctor.idEspecialidad = Doctor.idEspecialidad;
            }
            db.SaveChanges();


            return RedirectToAction("Index", "Doctor");
        }

        public ActionResult Edit(int? id)
        {
            var elDoctor = db.tblDoctors.SqlQuery("SELECT * FROM tblDoctor WHERE idDoctor = " + id).SingleOrDefault();

            if (elDoctor == null)
                return HttpNotFound();

            var myViewM = new DoctorViewModel
            {
                doctor = elDoctor,
                listaEspecialidad = db.tblEspecialidads.SqlQuery("SELECT * FROM tblEspecialidad").ToList()
            };

            return View("DoctorForm", myViewM);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            var doctor = db.tblDoctors.SqlQuery("SELECT * FROM tblDoctor WHERE idDoctor = " + id).SingleOrDefault();

            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        [HttpPost][ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {

            db.Database.ExecuteSqlCommand("DELETE FROM tblDoctor WHERE idDoctor = " + id);
            db.SaveChanges();

            return RedirectToAction("Index", "Doctor");
        }



    }
}