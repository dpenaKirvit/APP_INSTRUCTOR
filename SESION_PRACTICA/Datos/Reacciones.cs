using System;
using System.Collections.Generic;

namespace SESION_PRACTICA.Datos
{
    public partial class Reacciones
    {
        public Guid Oid { get; set; }
        public int? Etiqueta { get; set; }
        public string NombreReaccion { get; set; }
        public int? MaterialApoyo { get; set; }
        public int? SubPanel { get; set; }
        public int? TipoReacción { get; set; }
        public int? Instrumento { get; set; }
        public int? Acciones { get; set; }
        public double? ValorInicio { get; set; }
        public double? ValorFin { get; set; }
        public double? TiempoInicio { get; set; }
        public double? Duración { get; set; }
        public bool? Oscila { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? Gcrecord { get; set; }

        public virtual Acciones AccionesNavigation { get; set; }
        public virtual Etiqueta EtiquetaNavigation { get; set; }
        public virtual Instrumento InstrumentoNavigation { get; set; }
        public virtual MaterialApoyo MaterialApoyoNavigation { get; set; }
        public virtual SubPanel SubPanelNavigation { get; set; }
    }
}
