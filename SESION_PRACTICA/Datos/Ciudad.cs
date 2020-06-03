using System;
using System.Collections.Generic;

namespace SESION_PRACTICA.Datos
{
    public partial class Ciudad
    {
        public Ciudad()
        {
            Instalacion = new HashSet<Instalacion>();
            Institución = new HashSet<Institución>();
            PersonaCiudadOrigenNavigation = new HashSet<Persona>();
            PersonaCiudadResidenciaNavigation = new HashSet<Persona>();
        }

        public int Oid { get; set; }
        public string NombreCiudad { get; set; }
        public string Departamento { get; set; }
        public string País { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? Gcrecord { get; set; }

        public virtual ICollection<Instalacion> Instalacion { get; set; }
        public virtual ICollection<Institución> Institución { get; set; }
        public virtual ICollection<Persona> PersonaCiudadOrigenNavigation { get; set; }
        public virtual ICollection<Persona> PersonaCiudadResidenciaNavigation { get; set; }
    }
}
