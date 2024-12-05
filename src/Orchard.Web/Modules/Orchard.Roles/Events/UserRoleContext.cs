using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Security;

namespace Orchard.Roles.Events {
    public class UserRoleContext : RoleContext {
        public IUser User { get; set; }
    }
}
