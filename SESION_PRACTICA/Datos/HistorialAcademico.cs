using System;
using System.Collections.Generic;

namespace SESION_PRACTICA.Datos
{
    public partial class HistorialAcademico
    {
        public int Oid { get; set; }
        public int? Grupo { get; set; }
        public int? Curso { get; set; }
        public Guid? Persona { get; set; }
        public int? EstadoMateria { get; set; }
        public int? MateriaTeóricas { get; set; }
        public int? MateriaPractica { get; set; }
        public double? TiempoEstudiado { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? Gcrecord { get; set; }

        public virtual Curso CursoNavigation { get; set; }
        public virtual Estado EstadoMateriaNavigation { get; set; }
        public virtual Grupo GrupoNavigation { get; set; }
        public virtual MateriasPrácticas MateriaPracticaNavigation { get; set; }
        public virtual MateriasTeóricas MateriaTeóricasNavigation { get; set; }
        public virtual Persona PersonaNavigation { get; set; }
    }
}
