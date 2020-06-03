using System;
using System.Collections.Generic;

namespace SESION_PRACTICA.Datos
{
    public partial class Estado
    {
        public Estado()
        {
            Grupo = new HashSet<Grupo>();
            HistorialAcademico = new HashSet<HistorialAcademico>();
        }

        public int Oid { get; set; }
        public string NombreEstado { get; set; }
        public string Descripción { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? Gcrecord { get; set; }

        public virtual ICollection<Grupo> Grupo { get; set; }
        public virtual ICollection<HistorialAcademico> HistorialAcademico { get; set; }
    }
}
