using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Autoroute.Settings {

    /// <summary>
    /// Models the patterns you can choose from
    /// </summary>
    public class RoutePattern {
        public string Name { get; set; }
        public string Pattern { get; set; }
        public string Description { get; set; }
        public string Culture { get; set; }
    }
}
