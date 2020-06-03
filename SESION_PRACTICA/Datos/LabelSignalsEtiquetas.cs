using System;
using System.Collections.Generic;

namespace SESION_PRACTICA.Datos
{
    public partial class LabelSignalsEtiquetas
    {
        public int Oid { get; set; }
        public string Valor { get; set; }
        public int? Etiquetas { get; set; }
        public int? SenalElectronica { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? Gcrecord { get; set; }

        public virtual Etiqueta EtiquetasNavigation { get; set; }
        public virtual SenalElectronica SenalElectronicaNavigation { get; set; }
    }
}
