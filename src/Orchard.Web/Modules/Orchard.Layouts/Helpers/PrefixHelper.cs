using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.Layouts.Helpers {
    public static class PrefixHelper {
        public static string AppendPrefix(this string currentPrefix, string additionalPrefix) {
            return String.IsNullOrWhiteSpace(currentPrefix) ? additionalPrefix : currentPrefix + "." + additionalPrefix;
        }
    }
}
