using System;
using System.Collections.Generic;

namespace SESION_PRACTICA.Datos
{
    public partial class PermissionPolicyRole
    {
        public PermissionPolicyRole()
        {
            PermissionPolicyActionPermissionObject = new HashSet<PermissionPolicyActionPermissionObject>();
            PermissionPolicyNavigationPermissionsObject = new HashSet<PermissionPolicyNavigationPermissionsObject>();
            PermissionPolicyTypePermissionsObject = new HashSet<PermissionPolicyTypePermissionsObject>();
            PermissionPolicyUserUsersPermissionPolicyRoleRoles = new HashSet<PermissionPolicyUserUsersPermissionPolicyRoleRoles>();
        }

        public Guid Oid { get; set; }
        public string Name { get; set; }
        public bool? IsAdministrative { get; set; }
        public bool? CanEditModel { get; set; }
        public int? PermissionPolicy { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? Gcrecord { get; set; }
        public int? ObjectType { get; set; }

        public virtual XpobjectType ObjectTypeNavigation { get; set; }
        public virtual ICollection<PermissionPolicyActionPermissionObject> PermissionPolicyActionPermissionObject { get; set; }
        public virtual ICollection<PermissionPolicyNavigationPermissionsObject> PermissionPolicyNavigationPermissionsObject { get; set; }
        public virtual ICollection<PermissionPolicyTypePermissionsObject> PermissionPolicyTypePermissionsObject { get; set; }
        public virtual ICollection<PermissionPolicyUserUsersPermissionPolicyRoleRoles> PermissionPolicyUserUsersPermissionPolicyRoleRoles { get; set; }
    }
}
