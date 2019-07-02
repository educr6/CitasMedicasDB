using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalCitasMedicas.ViewModel
{
    public class DoctorViewModel
    {
        public tblDoctor doctor { get; set; }
        public tblEspecialidad especialidad { get; set; }
        public List<tblEspecialidad> listaEspecialidad { get; set; }
    }
}