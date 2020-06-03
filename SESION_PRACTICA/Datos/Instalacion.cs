using System;
using System.Collections.Generic;

namespace SESION_PRACTICA.Datos
{
    public partial class Instalacion
    {
        public Instalacion()
        {
            EvaluacionTeorica = new HashSet<EvaluacionTeorica>();
        }

        public int Oid { get; set; }
        public string Nombre { get; set; }
        public string NombreAbreviado { get; set; }
        public int? Ciudad { get; set; }
        public string RutaBasesDeDatos { get; set; }
        public string RutaCalibracion { get; set; }
        public int? TipoIdentidad { get; set; }
        public string NúmeroIdentidad { get; set; }
        public string NombreComandante { get; set; }
        public int? GradoComandante { get; set; }
        public string CódigoAcceso { get; set; }
        public DateTime? FechaInstalación { get; set; }
        public DateTime? FechaBackup { get; set; }
        public DateTime? FechaActualización { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? Gcrecord { get; set; }

        public virtual Ciudad CiudadNavigation { get; set; }
        public virtual Grado GradoComandanteNavigation { get; set; }
        public virtual TipoIdentidad TipoIdentidadNavigation { get; set; }
        public virtual ICollection<EvaluacionTeorica> EvaluacionTeorica { get; set; }
    }
}
