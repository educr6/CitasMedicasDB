using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalCitasMedicas.ViewModel;

namespace FinalCitasMedicas.Controllers
{
    public class PacienteController : Controller
    {
        protected dbCitasMedicasEntities1 db = new dbCitasMedicasEntities1();
        // GET: Paciente
        public ActionResult Index()
        {
            var pacientes = db.tblPacientes.SqlQuery("SELECT * FROM tblPaciente").ToList();
            var pacienteList = new List<PacienteViewModel>();
            ViewBag.isAdmin = TipoUsuarioElegido.isAdmin;


            for (int i = 0; i < pacientes.Count(); i++)
            {
                pacienteList.Add(
                    new PacienteViewModel()
                    {
                        paciente = pacientes[i],
                        seguro = db.tblSeguroes.SqlQuery("SELECT * FROM tblSeguro WHERE idSeguro = " + pacientes[i].idSeguro).FirstOrDefault(),
                        isAdmin = TipoUsuarioElegido.isAdmin
                    }
                );
            }

            return View(pacienteList);
        }

        public ActionResult New()
        {

            var seguros = db.tblSeguroes.SqlQuery("SELECT * FROM tblSeguro").ToList();
            var viewModel = new PacienteViewModel
            {
                listSeguro = seguros
            };

            return View("PacienteForm" ,viewModel);
        }

        [HttpPost]
        public ActionResult Save(tblPaciente paciente)
        {
            if (paciente.idPaciente == 0)
            {
                db.Database.ExecuteSqlCommand("INSERT INTO tblPaciente VALUES " +
                    "(@idSeguro, @nombre, @cedula, @fechanacimiento, @correo, @telefono, @direccion)",
                    new SqlParameter("idSeguro", paciente.idSeguro),
                    new SqlParameter("nombre", paciente.nombrePaciente),
                    new SqlParameter("cedula", paciente.cedulaPaciente),
                    new SqlParameter("fechanacimiento", paciente.fechaNacimientoPaciente),
                    new SqlParameter("correo", paciente.correoPaciente),
                    new SqlParameter("telefono", paciente.telefonoPaciente),
                    new SqlParameter("direccion", paciente.direccionPaciente)
                    );
            }
            else
            {
                var elpaciente = db.tblPacientes.SqlQuery("SELECT * FROM tblPaciente WHERE idPaciente = '" + paciente.idPaciente + "'").SingleOrDefault();
                elpaciente.nombrePaciente = paciente.nombrePaciente;
                elpaciente.cedulaPaciente = paciente.cedulaPaciente;
                elpaciente.fechaNacimientoPaciente = paciente.fechaNacimientoPaciente;
                elpaciente.correoPaciente = paciente.correoPaciente;
                elpaciente.telefonoPaciente = paciente.telefonoPaciente;
                elpaciente.direccionPaciente = paciente.direccionPaciente;
                elpaciente.idSeguro = paciente.idSeguro;
            }
            db.SaveChanges();
            

            return RedirectToAction("Index", "Paciente");
        }

        public ActionResult Edit (int? id)
        {
            var elpaciente = db.tblPacientes.SqlQuery("SELECT * FROM tblPaciente WHERE idPaciente = " + id ).SingleOrDefault();

            if (elpaciente == null)
                return HttpNotFound();

            var myViewM = new PacienteViewModel
            {
                paciente = elpaciente,
                listSeguro = db.tblSeguroes.SqlQuery("SELECT * FROM tblSeguro").ToList()
            };

            return View("PacienteForm", myViewM);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            var paciente = db.tblPacientes.SqlQuery("SELECT * FROM tblPaciente WHERE idPaciente = " + id).SingleOrDefault();

            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        [HttpPost][ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {

            db.Database.ExecuteSqlCommand("DELETE FROM tblPaciente WHERE idPaciente = " + id);
            db.SaveChanges();

            return RedirectToAction("Index", "Paciente");
        }


    }
}