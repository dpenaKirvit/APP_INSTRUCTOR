using System;
using System.Collections.Generic;

namespace SESION_PRACTICA.Datos
{
    public partial class Institución
    {
        public Institución()
        {
            Persona = new HashSet<Persona>();
        }

        public int Oid { get; set; }
        public string Nombre { get; set; }
        public int? Ciudad { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? Gcrecord { get; set; }

        public virtual Ciudad CiudadNavigation { get; set; }
        public virtual ICollection<Persona> Persona { get; set; }
    }
}
