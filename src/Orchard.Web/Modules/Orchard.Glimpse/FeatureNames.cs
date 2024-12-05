using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Glimpse {
    internal static class FeatureNames {
        internal const string Authorizer = "Orchard.Glimpse.Authorizer";
        internal const string Cache = "Orchard.Glimpse.Cache";
        internal const string ContentManager = "Orchard.Glimpse.ContentManager";
        internal const string Layers = "Orchard.Glimpse.Layers";
        internal const string Parts = "Orchard.Glimpse.Parts";
        internal const string Shapes = "Orchard.Glimpse.Shapes";
        internal const string SQL = "Orchard.Glimpse.SQL";
        internal const string Widgets = "Orchard.Glimpse.Widgets";
    }
}
