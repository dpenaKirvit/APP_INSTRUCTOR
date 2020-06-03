using System;
using System.Collections.Generic;

namespace SESION_PRACTICA.Datos
{
    public partial class FileData
    {
        public FileData()
        {
            MaterialApoyo = new HashSet<MaterialApoyo>();
            MateriasPrácticas = new HashSet<MateriasPrácticas>();
            MateriasTeóricas = new HashSet<MateriasTeóricas>();
        }

        public Guid Oid { get; set; }
        public int? Size { get; set; }
        public string FileName { get; set; }
        public byte[] Content { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? Gcrecord { get; set; }

        public virtual ICollection<MaterialApoyo> MaterialApoyo { get; set; }
        public virtual ICollection<MateriasPrácticas> MateriasPrácticas { get; set; }
        public virtual ICollection<MateriasTeóricas> MateriasTeóricas { get; set; }
    }
}
