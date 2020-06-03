using System;
using System.Collections.Generic;

namespace SESION_PRACTICA.Datos
{
    public partial class AreasAcademicas
    {
        public AreasAcademicas()
        {
            MateriasPrácticas = new HashSet<MateriasPrácticas>();
            MateriasTeóricas = new HashSet<MateriasTeóricas>();
        }

        public int Oid { get; set; }
        public string Título { get; set; }
        public string Descripción { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? Gcrecord { get; set; }

        public virtual ICollection<MateriasPrácticas> MateriasPrácticas { get; set; }
        public virtual ICollection<MateriasTeóricas> MateriasTeóricas { get; set; }
    }
}
