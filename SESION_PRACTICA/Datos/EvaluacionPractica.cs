using System;
using System.Collections.Generic;

namespace SESION_PRACTICA.Datos
{
    public partial class EvaluacionPractica
    {
        public int Oid { get; set; }
        public int? SesiónPráctica { get; set; }
        public double? Calificación { get; set; }
        public string NoReporte { get; set; }
        public int? ChecklistEvaluado { get; set; }
        public string Observaciones { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? Gcrecord { get; set; }

        public virtual CheckList ChecklistEvaluadoNavigation { get; set; }
        public virtual SesionPractica SesiónPrácticaNavigation { get; set; }
    }
}
