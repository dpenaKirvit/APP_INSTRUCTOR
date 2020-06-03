using System;
using System.Collections.Generic;

namespace SESION_PRACTICA.Datos
{
    public partial class EvaluacionTeorica
    {
        public int Oid { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public Guid? Estudiante { get; set; }
        public int? Materia { get; set; }
        public double? Calificación { get; set; }
        public string NoReporte { get; set; }
        public int? RegistroInstalación { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? Gcrecord { get; set; }

        public virtual Persona EstudianteNavigation { get; set; }
        public virtual MateriasTeóricas MateriaNavigation { get; set; }
        public virtual Instalacion RegistroInstalaciónNavigation { get; set; }
    }
}
