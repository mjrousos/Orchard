using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Roles.Models {
    public class RolesPermissionsRecord {
        public virtual int Id { get; set; }
        public virtual RoleRecord Role { get; set; }
        public virtual PermissionRecord Permission { get; set; }
    }
}
