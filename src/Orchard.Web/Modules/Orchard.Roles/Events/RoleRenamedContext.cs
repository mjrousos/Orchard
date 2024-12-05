using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Roles.Events {
    public class RoleRenamedContext : RoleContext {
        public string PreviousRoleName { get; set; }
        public string NewRoleName { get; set; }
    }
}
