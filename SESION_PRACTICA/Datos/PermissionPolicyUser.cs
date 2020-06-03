using System;
using System.Collections.Generic;

namespace SESION_PRACTICA.Datos
{
    public partial class PermissionPolicyUser
    {
        public PermissionPolicyUser()
        {
            PermissionPolicyUserUsersPermissionPolicyRoleRoles = new HashSet<PermissionPolicyUserUsersPermissionPolicyRoleRoles>();
        }

        public Guid Oid { get; set; }
        public string StoredPassword { get; set; }
        public bool? ChangePasswordOnFirstLogon { get; set; }
        public string UserName { get; set; }
        public bool? IsActive { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? Gcrecord { get; set; }
        public int? ObjectType { get; set; }

        public virtual XpobjectType ObjectTypeNavigation { get; set; }
        public virtual Persona Persona { get; set; }
        public virtual ICollection<PermissionPolicyUserUsersPermissionPolicyRoleRoles> PermissionPolicyUserUsersPermissionPolicyRoleRoles { get; set; }
    }
}
