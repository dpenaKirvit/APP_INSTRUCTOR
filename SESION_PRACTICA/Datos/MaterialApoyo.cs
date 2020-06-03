using System;
using System.Collections.Generic;

namespace SESION_PRACTICA.Datos
{
    public partial class MaterialApoyo
    {
        public MaterialApoyo()
        {
            MateriasPrácticasMateriasPrácticasMaterialApoyoMaterialApoyos = new HashSet<MateriasPrácticasMateriasPrácticasMaterialApoyoMaterialApoyos>();
            MateriasTeóricasMateriasTeóricasMaterialApoyoMaterialApoyos = new HashSet<MateriasTeóricasMateriasTeóricasMaterialApoyoMaterialApoyos>();
            Reacciones = new HashSet<Reacciones>();
        }

        public int Oid { get; set; }
        public string Nombre { get; set; }
        public int? TipoMaterial { get; set; }
        public Guid? Archivo { get; set; }
        public string Url { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? Gcrecord { get; set; }

        public virtual FileData ArchivoNavigation { get; set; }
        public virtual TipoMaterial TipoMaterialNavigation { get; set; }
        public virtual ICollection<MateriasPrácticasMateriasPrácticasMaterialApoyoMaterialApoyos> MateriasPrácticasMateriasPrácticasMaterialApoyoMaterialApoyos { get; set; }
        public virtual ICollection<MateriasTeóricasMateriasTeóricasMaterialApoyoMaterialApoyos> MateriasTeóricasMateriasTeóricasMaterialApoyoMaterialApoyos { get; set; }
        public virtual ICollection<Reacciones> Reacciones { get; set; }
    }
}
