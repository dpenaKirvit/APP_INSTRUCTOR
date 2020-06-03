using System;
using System.Collections.Generic;

namespace SESION_PRACTICA.Datos
{
    public partial class PuntosCalibracionInstrumentos
    {
        public int Oid { get; set; }
        public int? Señal { get; set; }
        public DateTime? FechaCalibracion { get; set; }
        public string NombreOperador { get; set; }
        public string Valor { get; set; }
        public int? ValorPunto10 { get; set; }
        public int? ValorPunto20 { get; set; }
        public int? ValorPunto30 { get; set; }
        public int? ValorPunto40 { get; set; }
        public int? ValorPunto50 { get; set; }
        public int? ValorPunto60 { get; set; }
        public int? ValorPunto70 { get; set; }
        public int? ValorPunto80 { get; set; }
        public int? ValorPunto90 { get; set; }
        public int? ValorPunto100 { get; set; }
        public int? ValorPunto110 { get; set; }
        public int? ValorPunto120 { get; set; }
        public int? ValorPunto130 { get; set; }
        public int? ValorPunto140 { get; set; }
        public int? ValorPunto150 { get; set; }
        public int? ValorPunto160 { get; set; }
        public int? ValorPunto170 { get; set; }
        public int? ValorPunto180 { get; set; }
        public int? ValorPunto190 { get; set; }
        public int? ValorPunto200 { get; set; }
        public int? ValorPunto210 { get; set; }
        public int? ValorPunto220 { get; set; }
        public int? ValorPunto230 { get; set; }
        public int? ValorPunto240 { get; set; }
        public int? ValorPunto250 { get; set; }
        public int? ValorPunto260 { get; set; }
        public int? ValorPunto270 { get; set; }
        public int? ValorPunto280 { get; set; }
        public int? ValorPunto290 { get; set; }
        public int? ValorPunto300 { get; set; }
        public int? ValorPunto310 { get; set; }
        public int? ValorPunto320 { get; set; }
        public int? ValorPunto330 { get; set; }
        public int? ValorPunto340 { get; set; }
        public int? ValorPunto350 { get; set; }
        public int? ValorPunto0Min { get; set; }
        public int? ValorPunto360Max { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? Gcrecord { get; set; }

        public virtual SenalElectronica SeñalNavigation { get; set; }
    }
}
