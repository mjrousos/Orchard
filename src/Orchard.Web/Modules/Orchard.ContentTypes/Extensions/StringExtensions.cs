using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.ContentTypes.Extensions {
    public static class StringExtensions {
        public static string TrimEnd(this string rough, string trim = "") {
            if (rough == null)
                return null;

            return rough.EndsWith(trim)
                       ? rough.Substring(0, rough.Length - trim.Length)
                       : rough;
        }
    }
}
