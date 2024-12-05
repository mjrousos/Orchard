using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Azure.MediaServices.Helpers {
    public static class BooleanExtensions {
        public static string ToYesNo(this bool value) {
            return value ? "Yes" : "No";
        }
    }
}
