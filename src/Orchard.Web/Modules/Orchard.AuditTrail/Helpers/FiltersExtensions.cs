using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.AuditTrail.Services.Models;

namespace Orchard.AuditTrail.Helpers {
    public static class FiltersExtensions {
        public static string Get(this Filters filters, string key) {
            if (!filters.ContainsKey(key))
                return null;
            return filters[key];
        }
    }
}
