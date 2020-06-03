using System;
using System.Collections.Generic;

namespace SESION_PRACTICA.Datos
{
    public partial class Grupo
    {
        public Grupo()
        {
            HistorialAcademico = new HashSet<HistorialAcademico>();
            PersonaEstudiantesGrupoGruposEstudiantes = new HashSet<PersonaEstudiantesGrupoGruposEstudiantes>();
            PersonaInstructoresGrupoGruposInstructores = new HashSet<PersonaInstructoresGrupoGruposInstructores>();
        }

        public int Oid { get; set; }
        public string Título { get; set; }
        public int? CursoAsociado { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int? EstadoCurso { get; set; }
        public string Observaciones { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? Gcrecord { get; set; }

        public virtual Curso CursoAsociadoNavigation { get; set; }
        public virtual Estado EstadoCursoNavigation { get; set; }
        public virtual ICollection<HistorialAcademico> HistorialAcademico { get; set; }
        public virtual ICollection<PersonaEstudiantesGrupoGruposEstudiantes> PersonaEstudiantesGrupoGruposEstudiantes { get; set; }
        public virtual ICollection<PersonaInstructoresGrupoGruposInstructores> PersonaInstructoresGrupoGruposInstructores { get; set; }
    }
}
