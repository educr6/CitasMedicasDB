using FinalCitasMedicas.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalCitasMedicas.Controllers
{
    public class CitaController : Controller
    {
        protected dbCitasMedicasEntities1 db = new dbCitasMedicasEntities1();

        // GET: Cita
        public ActionResult Index()
        {

            ViewBag.isAdmin = TipoUsuarioElegido.isAdmin;

            var citas = db.tblCitas.SqlQuery("SELECT * FROM tblCita").ToList();
            var citaViewModel = new List<CitaViewModel>();


            for (int i = 0; i < citas.Count(); i++)
            {
                citaViewModel.Add(
                    new CitaViewModel()
                    {
                        miCita = citas[i],
                        miDoctor = db.tblDoctors.SqlQuery("SELECT * FROM tblDoctor WHERE idDoctor = " + citas[i].idDoctor).FirstOrDefault(),
                        miPaciente = db.tblPacientes.SqlQuery("SELECT * FROM tblPaciente WHERE idPaciente = " + citas[i].idPaciente).FirstOrDefault(),
                        miCentro = db.tblCentroMedicoes.SqlQuery("SELECT * FROM tblCentroMedico WHERE idCentroMedico = " + citas[i].idCentroMedico).FirstOrDefault(),
                        miEstado = db.tblEstadoCitas.SqlQuery("SELECT * FROM tblEstadoCita WHERE idEstado = " + citas[i].idEstadoCita).FirstOrDefault()
                    }
                );
            }

            return View(citaViewModel);
        }


        public ActionResult New()
        {

            var dotores = db.tblDoctors.SqlQuery("SELECT * FROM tblDoctor").ToList();
            var pacientes = db.tblPacientes.SqlQuery("SELECT * FROM tblPaciente").ToList();
            var centros = db.tblCentroMedicoes.SqlQuery("SELECT * FROM tblCentroMedico").ToList();
            var estados = db.tblEstadoCitas.SqlQuery("SELECT * FROM tblEstadoCita").ToList();

            var citaViewModel = new CitaViewModel
            {
                listaDoctores = dotores,
                listaPacientes = pacientes,
                listaCentrosMedicos = centros,
                listaEstados = estados
            };

            return View("CitaForm", citaViewModel);
        }


        [HttpPost]
        public ActionResult Save(CitaViewModel viewModel)
        {
            if (viewModel.miCita.idCita == 0)
            {
                db.Database.ExecuteSqlCommand("INSERT INTO tblCita VALUES " +
                    "(@idDoctor, @idPaciente, @idCentro, @idEstado, @fecha, @hora)",
                    new SqlParameter("idDoctor", viewModel.miCita.idDoctor),
                    new SqlParameter("idPaciente", viewModel.miCita.idPaciente),
                    new SqlParameter("idCentro", viewModel.miCita.idCentroMedico),
                    new SqlParameter("idEstado", viewModel.miCita.idEstadoCita),
                    new SqlParameter("fecha", viewModel.miCita.fechaCita),
                    new SqlParameter("hora", viewModel.miCita.horaCita)
                    );
            }
            else
            {
                var laCita = db.tblCitas.SqlQuery("SELECT * FROM tblCita WHERE idCita = " + viewModel.miCita.idCita).SingleOrDefault();
                laCita.idDoctor = viewModel.miCita.idDoctor;
                laCita.idPaciente = viewModel.miCita.idPaciente;
                laCita.idCentroMedico = viewModel.miCita.idCentroMedico;
                laCita.idEstadoCita = viewModel.miCita.idEstadoCita;
                laCita.fechaCita = viewModel.miCita.fechaCita;
                laCita.horaCita = viewModel.miCita.horaCita;
            }
            db.SaveChanges();


            return RedirectToAction("Index", "Cita");
        }


        public ActionResult Edit(int? id)
        {
            var laCita = db.tblCitas.SqlQuery("SELECT * FROM tblCita WHERE idCita = " + id).SingleOrDefault();

            if (laCita == null)
                return HttpNotFound();

            var dotores = db.tblDoctors.SqlQuery("SELECT * FROM tblDoctor").ToList();
            var pacientes = db.tblPacientes.SqlQuery("SELECT * FROM tblPaciente").ToList();
            var centros = db.tblCentroMedicoes.SqlQuery("SELECT * FROM tblCentroMedico").ToList();
            var estados = db.tblEstadoCitas.SqlQuery("SELECT * FROM tblEstadoCita").ToList();

            var myViewM = new CitaViewModel()
            {
                miCita = laCita,
                listaDoctores = dotores,
                listaPacientes = pacientes,
                listaCentrosMedicos = centros,
                listaEstados = estados
            };

            return View("CitaForm", myViewM);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            var laCita = db.tblCitas.SqlQuery("SELECT * FROM tblCita WHERE idCita = " + id).SingleOrDefault();

            if (laCita == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CitaViewModel()
            {
                miCita = laCita,
                miDoctor = db.tblDoctors.SqlQuery("SELECT * FROM tblDoctor WHERE idDoctor = " + laCita.idDoctor).FirstOrDefault(),
                miPaciente = db.tblPacientes.SqlQuery("SELECT * FROM tblPaciente WHERE idPaciente = " + laCita.idPaciente).FirstOrDefault(),
                miCentro = db.tblCentroMedicoes.SqlQuery("SELECT * FROM tblCentroMedico WHERE idCentroMedico = " + laCita.idCentroMedico).FirstOrDefault()
            };

            return View("Delete", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {

            db.Database.ExecuteSqlCommand("DELETE FROM tblCita WHERE idCita = " + id);
            db.SaveChanges();

            return RedirectToAction("Index", "Cita");
        }

    }
}