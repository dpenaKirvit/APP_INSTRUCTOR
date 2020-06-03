using System;
using System.Collections.Generic;

namespace SESION_PRACTICA.Datos
{
    public partial class Etiqueta
    {
        public Etiqueta()
        {
            Acciones = new HashSet<Acciones>();
            LabelSignalsEtiquetas = new HashSet<LabelSignalsEtiquetas>();
            ParametroInicial = new HashSet<ParametroInicial>();
            Reacciones = new HashSet<Reacciones>();
        }

        public int Oid { get; set; }
        public string Nombre { get; set; }
        public int? Instrumento { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? Gcrecord { get; set; }

        public virtual Instrumento InstrumentoNavigation { get; set; }
        public virtual ICollection<Acciones> Acciones { get; set; }
        public virtual ICollection<LabelSignalsEtiquetas> LabelSignalsEtiquetas { get; set; }
        public virtual ICollection<ParametroInicial> ParametroInicial { get; set; }
        public virtual ICollection<Reacciones> Reacciones { get; set; }
    }
}
