using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Linq;
using System.Web.UI;

namespace Orchard.OutputCache.Helpers {
    public static class OutputCacheAttributeExtensions {
        /// <summary>
        /// Returns true if the Location of the specified output cache attribute matches any of the specified list of locations.
        /// </summary>
        public static bool LocationIsIn(this OutputCacheAttribute attribute, params OutputCacheLocation[] locations) {
            return locations.Contains(attribute.Location);
        }
    }
}
