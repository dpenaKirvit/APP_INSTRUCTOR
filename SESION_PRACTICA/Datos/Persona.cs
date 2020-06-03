using System;
using System.Collections.Generic;

namespace SESION_PRACTICA.Datos
{
    public partial class Persona
    {
        public Persona()
        {
            Certificaciones = new HashSet<Certificaciones>();
            EvaluacionTeorica = new HashSet<EvaluacionTeorica>();
            HistorialAcademico = new HashSet<HistorialAcademico>();
            PersonaEstudiantesGrupoGruposEstudiantes = new HashSet<PersonaEstudiantesGrupoGruposEstudiantes>();
            PersonaInstructoresGrupoGruposInstructores = new HashSet<PersonaInstructoresGrupoGruposInstructores>();
            SesionPracticaCopilotoNavigation = new HashSet<SesionPractica>();
            SesionPracticaIngenieroDeVueloNavigation = new HashSet<SesionPractica>();
            SesionPracticaInstructorNavigation = new HashSet<SesionPractica>();
            SesionPracticaPilotoNavigation = new HashSet<SesionPractica>();
        }

        public Guid Oid { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int? Género { get; set; }
        public int? TipoIdentidad { get; set; }
        public string NúmeroIdentidad { get; set; }
        public int? CiudadOrigen { get; set; }
        public int? CiudadResidencia { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Teléfono { get; set; }
        public string Celular { get; set; }
        public string Dirección { get; set; }
        public string CorreoElectrónico { get; set; }
        public int? Institución { get; set; }
        public int? Grado { get; set; }
        public byte[] Foto { get; set; }

        public virtual Ciudad CiudadOrigenNavigation { get; set; }
        public virtual Ciudad CiudadResidenciaNavigation { get; set; }
        public virtual Grado GradoNavigation { get; set; }
        public virtual Institución InstituciónNavigation { get; set; }
        public virtual PermissionPolicyUser O { get; set; }
        public virtual TipoIdentidad TipoIdentidadNavigation { get; set; }
        public virtual ICollection<Certificaciones> Certificaciones { get; set; }
        public virtual ICollection<EvaluacionTeorica> EvaluacionTeorica { get; set; }
        public virtual ICollection<HistorialAcademico> HistorialAcademico { get; set; }
        public virtual ICollection<PersonaEstudiantesGrupoGruposEstudiantes> PersonaEstudiantesGrupoGruposEstudiantes { get; set; }
        public virtual ICollection<PersonaInstructoresGrupoGruposInstructores> PersonaInstructoresGrupoGruposInstructores { get; set; }
        public virtual ICollection<SesionPractica> SesionPracticaCopilotoNavigation { get; set; }
        public virtual ICollection<SesionPractica> SesionPracticaIngenieroDeVueloNavigation { get; set; }
        public virtual ICollection<SesionPractica> SesionPracticaInstructorNavigation { get; set; }
        public virtual ICollection<SesionPractica> SesionPracticaPilotoNavigation { get; set; }
    }
}
