using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Projections.Models;

namespace Orchard.Projections.ViewModels {
    public class QueryViewModel {
        public QueryVersionScopeOptions VersionScope { get; set; }
    }
}
