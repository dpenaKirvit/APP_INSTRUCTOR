using System;
using System.Collections.Generic;

namespace SESION_PRACTICA.Datos
{
    public partial class SenalElectronica
    {
        public SenalElectronica()
        {
            LabelSignalsEtiquetas = new HashSet<LabelSignalsEtiquetas>();
            PuntosCalibracionInstrumentos = new HashSet<PuntosCalibracionInstrumentos>();
        }

        public int Oid { get; set; }
        public int? Instrumento { get; set; }
        public string Nombre { get; set; }
        public string Board { get; set; }
        public int? Io { get; set; }
        public string Id { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? Gcrecord { get; set; }

        public virtual Instrumento InstrumentoNavigation { get; set; }
        public virtual ICollection<LabelSignalsEtiquetas> LabelSignalsEtiquetas { get; set; }
        public virtual ICollection<PuntosCalibracionInstrumentos> PuntosCalibracionInstrumentos { get; set; }
    }
}
