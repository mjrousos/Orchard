using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web.Hosting;

namespace Orchard.Environment.Extensions.Helpers {
    public static class PathHelpers {
        public static string GetPhysicalPath(string path) {
            if (path.StartsWith("~") && HostingEnvironment.IsHosted) {
                return HostingEnvironment.MapPath(path);
            }
            return path;
        }
    }
}
