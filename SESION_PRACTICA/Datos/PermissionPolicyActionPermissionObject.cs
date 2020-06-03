﻿using System;
using System.Collections.Generic;

namespace SESION_PRACTICA.Datos
{
    public partial class PermissionPolicyActionPermissionObject
    {
        public Guid Oid { get; set; }
        public string ActionId { get; set; }
        public Guid? Role { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? Gcrecord { get; set; }

        public virtual PermissionPolicyRole RoleNavigation { get; set; }
    }
}
