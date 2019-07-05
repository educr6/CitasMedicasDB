using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalCitasMedicas.ViewModel
{
    public class CitaViewModel
    {
        public List<tblDoctor> listaDoctores { get; set; }
        public List<tblPaciente> listaPacientes { get; set; }
        public List<tblCentroMedico> listaCentrosMedicos { get; set; }
        public List<tblEstadoCita> listaEstados { get; set; }
        public tblCita miCita { get; set; }
        public tblDoctor miDoctor { get; set; }
        public tblPaciente miPaciente { get; set; }
        public tblCentroMedico miCentro { get; set; }
        public tblEstadoCita miEstado { get; set; }

    }
}