using System;
using System.Collections.Generic;

namespace SESION_PRACTICA.Datos
{
    public partial class Reaccion
    {
        public Guid Oid { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? Gcrecord { get; set; }
    }
}
