using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.OutputCache.Models {
    public class CacheRouteConfig {
        public string RouteKey { get; set; }
        public string Url { get; set; }
        public int Priority { get; set; }
        public int? Duration { get; set; }
        public int? GraceTime { get; set; }
        public int? MaxAge { get; set; }
        public string FeatureName { get; set; }
    }
}
