using System;
using System.Collections.Generic;

namespace SESION_PRACTICA.Datos
{
    public partial class CheckList
    {
        public CheckList()
        {
            Acciones = new HashSet<Acciones>();
            EvaluacionPractica = new HashSet<EvaluacionPractica>();
        }

        public int Oid { get; set; }
        public string Título { get; set; }
        public int? MateriaPráctica { get; set; }
        public int? Rol { get; set; }
        public string Nota { get; set; }
        public string Nombre { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? Gcrecord { get; set; }

        public virtual MateriasPrácticas MateriaPrácticaNavigation { get; set; }
        public virtual ICollection<Acciones> Acciones { get; set; }
        public virtual ICollection<EvaluacionPractica> EvaluacionPractica { get; set; }
    }
}
