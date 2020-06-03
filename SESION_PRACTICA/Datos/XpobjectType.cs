using System;
using System.Collections.Generic;

namespace SESION_PRACTICA.Datos
{
    public partial class XpobjectType
    {
        public XpobjectType()
        {
            PermissionPolicyRole = new HashSet<PermissionPolicyRole>();
            PermissionPolicyUser = new HashSet<PermissionPolicyUser>();
            XpweakReferenceObjectTypeNavigation = new HashSet<XpweakReference>();
            XpweakReferenceTargetTypeNavigation = new HashSet<XpweakReference>();
        }

        public int Oid { get; set; }
        public string TypeName { get; set; }
        public string AssemblyName { get; set; }

        public virtual ICollection<PermissionPolicyRole> PermissionPolicyRole { get; set; }
        public virtual ICollection<PermissionPolicyUser> PermissionPolicyUser { get; set; }
        public virtual ICollection<XpweakReference> XpweakReferenceObjectTypeNavigation { get; set; }
        public virtual ICollection<XpweakReference> XpweakReferenceTargetTypeNavigation { get; set; }
    }
}
