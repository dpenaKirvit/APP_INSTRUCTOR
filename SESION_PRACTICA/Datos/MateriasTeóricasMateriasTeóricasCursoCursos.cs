using System;
using System.Collections.Generic;

namespace SESION_PRACTICA.Datos
{
    public partial class MateriasTeóricasMateriasTeóricasCursoCursos
    {
        public int? Cursos { get; set; }
        public int? MateriasTeóricas { get; set; }
        public int Oid { get; set; }
        public int? OptimisticLockField { get; set; }

        public virtual Curso CursosNavigation { get; set; }
        public virtual MateriasTeóricas MateriasTeóricasNavigation { get; set; }
    }
}
