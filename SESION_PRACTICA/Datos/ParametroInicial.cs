using System;
using System.Collections.Generic;

namespace SESION_PRACTICA.Datos
{
    public partial class ParametroInicial
    {
        public int Oid { get; set; }
        public int? SubPanel { get; set; }
        public int? Instrumento { get; set; }
        public int? MateriasPracticas { get; set; }
        public int? Etiqueta { get; set; }
        public string Valor { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? Gcrecord { get; set; }

        public virtual Etiqueta EtiquetaNavigation { get; set; }
        public virtual Instrumento InstrumentoNavigation { get; set; }
        public virtual MateriasPrácticas MateriasPracticasNavigation { get; set; }
        public virtual SubPanel SubPanelNavigation { get; set; }
    }
}
