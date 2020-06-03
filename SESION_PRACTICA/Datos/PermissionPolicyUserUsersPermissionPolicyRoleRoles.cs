﻿using System;
using System.Collections.Generic;

namespace SESION_PRACTICA.Datos
{
    public partial class PermissionPolicyUserUsersPermissionPolicyRoleRoles
    {
        public Guid? Roles { get; set; }
        public Guid? Users { get; set; }
        public Guid Oid { get; set; }
        public int? OptimisticLockField { get; set; }

        public virtual PermissionPolicyRole RolesNavigation { get; set; }
        public virtual PermissionPolicyUser UsersNavigation { get; set; }
    }
}
