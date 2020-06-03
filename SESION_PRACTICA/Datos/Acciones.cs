using System;
using System.Collections.Generic;

namespace SESION_PRACTICA.Datos
{
    public partial class Acciones
    {
        public Acciones()
        {
            Reacciones = new HashSet<Reacciones>();
        }

        public int Oid { get; set; }
        public string Nombre { get; set; }
        public int? Orden { get; set; }
        public int? CheckList { get; set; }
        public string Descripción { get; set; }
        public double? Valor { get; set; }
        public int? TipoAcción { get; set; }
        public double? TiempoEspera { get; set; }
        public double? TiempoDuracion { get; set; }
        public int? PilotoOcopiloto { get; set; }
        public int? Instrumento { get; set; }
        public int? SubPanel { get; set; }
        public int? Etiqueta { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? Gcrecord { get; set; }

        public virtual CheckList CheckListNavigation { get; set; }
        public virtual Etiqueta EtiquetaNavigation { get; set; }
        public virtual Instrumento InstrumentoNavigation { get; set; }
        public virtual SubPanel SubPanelNavigation { get; set; }
        public virtual ICollection<Reacciones> Reacciones { get; set; }
    }
}
