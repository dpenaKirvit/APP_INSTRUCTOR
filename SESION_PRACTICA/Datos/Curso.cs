using System;
using System.Collections.Generic;

namespace SESION_PRACTICA.Datos
{
    public partial class Curso
    {
        public Curso()
        {
            Grupo = new HashSet<Grupo>();
            HistorialAcademico = new HashSet<HistorialAcademico>();
            MateriasPrácticasMateriasPrácticasCursoCursos = new HashSet<MateriasPrácticasMateriasPrácticasCursoCursos>();
            MateriasTeóricasMateriasTeóricasCursoCursos = new HashSet<MateriasTeóricasMateriasTeóricasCursoCursos>();
        }

        public int Oid { get; set; }
        public string Título { get; set; }
        public string Descripción { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? Gcrecord { get; set; }

        public virtual ICollection<Grupo> Grupo { get; set; }
        public virtual ICollection<HistorialAcademico> HistorialAcademico { get; set; }
        public virtual ICollection<MateriasPrácticasMateriasPrácticasCursoCursos> MateriasPrácticasMateriasPrácticasCursoCursos { get; set; }
        public virtual ICollection<MateriasTeóricasMateriasTeóricasCursoCursos> MateriasTeóricasMateriasTeóricasCursoCursos { get; set; }
    }
}
