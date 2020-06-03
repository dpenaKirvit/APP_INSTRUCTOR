using System;
using System.Collections.Generic;

namespace SESION_PRACTICA.Datos
{
    public partial class KpiScorecard
    {
        public KpiScorecard()
        {
            KpiScorecardScorecardsKpiInstanceIndicators = new HashSet<KpiScorecardScorecardsKpiInstanceIndicators>();
        }

        public Guid Oid { get; set; }
        public string Name { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? Gcrecord { get; set; }

        public virtual ICollection<KpiScorecardScorecardsKpiInstanceIndicators> KpiScorecardScorecardsKpiInstanceIndicators { get; set; }
    }
}
