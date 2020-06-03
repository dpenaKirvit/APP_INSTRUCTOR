using System;
using System.Collections.Generic;

namespace SESION_PRACTICA.Datos
{
    public partial class MateriasPrácticasMateriasPrácticasMaterialApoyoMaterialApoyos
    {
        public int? MaterialApoyos { get; set; }
        public int? MateriasPrácticas { get; set; }
        public int Oid { get; set; }
        public int? OptimisticLockField { get; set; }

        public virtual MaterialApoyo MaterialApoyosNavigation { get; set; }
        public virtual MateriasPrácticas MateriasPrácticasNavigation { get; set; }
    }
}
