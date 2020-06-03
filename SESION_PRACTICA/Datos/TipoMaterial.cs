using System;
using System.Collections.Generic;

namespace SESION_PRACTICA.Datos
{
    public partial class TipoMaterial
    {
        public TipoMaterial()
        {
            MaterialApoyo = new HashSet<MaterialApoyo>();
        }

        public int Oid { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? Gcrecord { get; set; }

        public virtual ICollection<MaterialApoyo> MaterialApoyo { get; set; }
    }
}
