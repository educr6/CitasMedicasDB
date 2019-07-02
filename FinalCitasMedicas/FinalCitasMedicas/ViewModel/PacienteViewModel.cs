using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalCitasMedicas.ViewModel
{
    public class PacienteViewModel
    {

        public tblPaciente paciente { get; set; }
        public tblSeguro seguro { get; set; }
        public IEnumerable<tblSeguro> listSeguro { get; set; }
    }
}