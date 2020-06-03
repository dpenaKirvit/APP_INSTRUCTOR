using System;
using System.Collections.Generic;

namespace SESION_PRACTICA.Datos
{
    public partial class MateriasPrácticasMateriasPrácticasCursoCursos
    {
        public int? Cursos { get; set; }
        public int? MateriasPrácticas { get; set; }
        public int Oid { get; set; }
        public int? OptimisticLockField { get; set; }

        public virtual Curso CursosNavigation { get; set; }
        public virtual MateriasPrácticas MateriasPrácticasNavigation { get; set; }
    }
}
