using System;
using System.Collections.Generic;

namespace SESION_PRACTICA.Datos
{
    public partial class Instrumento
    {
        public Instrumento()
        {
            Acciones = new HashSet<Acciones>();
            Etiqueta = new HashSet<Etiqueta>();
            ParametroInicial = new HashSet<ParametroInicial>();
            Reacciones = new HashSet<Reacciones>();
            SenalElectronica = new HashSet<SenalElectronica>();
        }

        public int Oid { get; set; }
        public string NombreInstrumento { get; set; }
        public string Rango { get; set; }
        public int? TipoSeñal { get; set; }
        public int? Subpanel { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? Gcrecord { get; set; }

        public virtual SubPanel SubpanelNavigation { get; set; }
        public virtual ICollection<Acciones> Acciones { get; set; }
        public virtual ICollection<Etiqueta> Etiqueta { get; set; }
        public virtual ICollection<ParametroInicial> ParametroInicial { get; set; }
        public virtual ICollection<Reacciones> Reacciones { get; set; }
        public virtual ICollection<SenalElectronica> SenalElectronica { get; set; }
    }
}
