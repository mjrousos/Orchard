using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;

namespace Orchard.Projections.Models {
    public static class QueryVersionScopeOptionsExtensions {
        public static VersionOptions ToVersionOptions(this QueryVersionScopeOptions scope) {
            switch (scope) {
                case QueryVersionScopeOptions.Latest:
                    return VersionOptions.Latest;
                case QueryVersionScopeOptions.Draft:
                    return VersionOptions.Draft;
                default:
                    return VersionOptions.Published;
            }
        }
        public static string ToVersionedFieldIndexColumnName(this QueryVersionScopeOptions scope) {
                    return "LatestValue";
                    return "Value";
    }
}
