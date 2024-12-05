using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Azure.MediaServices.Helpers {
    public static class StringExtensions {
        public static string TrimSafe(this string value) {
            return value != null ? value.Trim() : null;
        }
    }
}
