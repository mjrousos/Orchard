using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Roles.Models;

namespace Orchard.Roles.Events {
    public class PermissionRoleContext : RoleContext {
        public PermissionRecord Permission { get; set; }
    }
}
