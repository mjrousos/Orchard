using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Roles.Models;

namespace Orchard.Roles.ViewModels {
    public class RolesIndexViewModel  {
        public IList<RoleRecord> Rows { get; set; }
    }
}
