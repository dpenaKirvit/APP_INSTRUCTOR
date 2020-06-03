using System;
using System.Collections.Generic;

namespace SESION_PRACTICA.Datos
{
    public partial class PersonaInstructoresGrupoGruposInstructores
    {
        public int? GruposInstructores { get; set; }
        public Guid? Instructores { get; set; }
        public int Oid { get; set; }
        public int? OptimisticLockField { get; set; }

        public virtual Grupo GruposInstructoresNavigation { get; set; }
        public virtual Persona InstructoresNavigation { get; set; }
    }
}
