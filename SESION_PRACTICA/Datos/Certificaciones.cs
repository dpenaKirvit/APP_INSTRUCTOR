using System;
using System.Collections.Generic;

namespace SESION_PRACTICA.Datos
{
    public partial class Certificaciones
    {
        public int Oid { get; set; }
        public Guid? Persona { get; set; }
        public string Título { get; set; }
        public string Institución { get; set; }
        public DateTime? FechaCulminación { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? Gcrecord { get; set; }

        public virtual Persona PersonaNavigation { get; set; }
    }
}
