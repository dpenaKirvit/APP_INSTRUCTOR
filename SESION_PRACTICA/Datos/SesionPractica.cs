using System;
using System.Collections.Generic;

namespace SESION_PRACTICA.Datos
{
    public partial class SesionPractica
    {
        public SesionPractica()
        {
            EvaluacionPractica = new HashSet<EvaluacionPractica>();
        }

        public int Oid { get; set; }
        public DateTime? Ingeniero { get; set; }
        public DateTime? FechaFin { get; set; }
        public double? Duración { get; set; }
        public Guid? Piloto { get; set; }
        public Guid? Copiloto { get; set; }
        public Guid? IngenieroDeVuelo { get; set; }
        public Guid? Instructor { get; set; }
        public int? MateriaPractica { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? Gcrecord { get; set; }

        public virtual Persona CopilotoNavigation { get; set; }
        public virtual Persona IngenieroDeVueloNavigation { get; set; }
        public virtual Persona InstructorNavigation { get; set; }
        public virtual MateriasPrácticas MateriaPracticaNavigation { get; set; }
        public virtual Persona PilotoNavigation { get; set; }
        public virtual ICollection<EvaluacionPractica> EvaluacionPractica { get; set; }
    }
}
