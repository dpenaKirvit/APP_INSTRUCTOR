using System;
using System.Collections.Generic;

namespace SESION_PRACTICA.Datos
{
    public partial class SubPanel
    {
        public SubPanel()
        {
            Acciones = new HashSet<Acciones>();
            Instrumento = new HashSet<Instrumento>();
            ParametroInicial = new HashSet<ParametroInicial>();
            Reacciones = new HashSet<Reacciones>();
        }

        public int Oid { get; set; }
        public string NombreSubpanel { get; set; }
        public string NombrePanelPrincipal { get; set; }
        public byte[] Imagen { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? Gcrecord { get; set; }

        public virtual ICollection<Acciones> Acciones { get; set; }
        public virtual ICollection<Instrumento> Instrumento { get; set; }
        public virtual ICollection<ParametroInicial> ParametroInicial { get; set; }
        public virtual ICollection<Reacciones> Reacciones { get; set; }
    }
}
