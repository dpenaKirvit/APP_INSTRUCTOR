using System;
using System.Collections.Generic;

namespace SESION_PRACTICA.Datos
{
    public partial class MateriasTeóricas
    {
        public MateriasTeóricas()
        {
            EvaluacionTeorica = new HashSet<EvaluacionTeorica>();
            HistorialAcademico = new HashSet<HistorialAcademico>();
            MateriasTeóricasMateriasTeóricasCursoCursos = new HashSet<MateriasTeóricasMateriasTeóricasCursoCursos>();
            MateriasTeóricasMateriasTeóricasMaterialApoyoMaterialApoyos = new HashSet<MateriasTeóricasMateriasTeóricasMaterialApoyoMaterialApoyos>();
        }

        public int Oid { get; set; }
        public string Título { get; set; }
        public string Descripción { get; set; }
        public int? AreaAcademica { get; set; }
        public double? IntensidadHoraria { get; set; }
        public Guid? Contenido { get; set; }
        public string Url { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? Gcrecord { get; set; }

        public virtual AreasAcademicas AreaAcademicaNavigation { get; set; }
        public virtual FileData ContenidoNavigation { get; set; }
        public virtual ICollection<EvaluacionTeorica> EvaluacionTeorica { get; set; }
        public virtual ICollection<HistorialAcademico> HistorialAcademico { get; set; }
        public virtual ICollection<MateriasTeóricasMateriasTeóricasCursoCursos> MateriasTeóricasMateriasTeóricasCursoCursos { get; set; }
        public virtual ICollection<MateriasTeóricasMateriasTeóricasMaterialApoyoMaterialApoyos> MateriasTeóricasMateriasTeóricasMaterialApoyoMaterialApoyos { get; set; }
    }
}
