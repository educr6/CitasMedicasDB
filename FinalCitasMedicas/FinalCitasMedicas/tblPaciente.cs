//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalCitasMedicas
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblPaciente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblPaciente()
        {
            this.tblCitas = new HashSet<tblCita>();
        }
    
        public int idPaciente { get; set; }
        public int idSeguro { get; set; }
        public string nombrePaciente { get; set; }
        public string cedulaPaciente { get; set; }
        public Nullable<System.DateTime> fechaNacimientoPaciente { get; set; }
        public string correoPaciente { get; set; }
        public string telefonoPaciente { get; set; }
        public string direccionPaciente { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCita> tblCitas { get; set; }
        public virtual tblSeguro tblSeguro { get; set; }
    }
}
