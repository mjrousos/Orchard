using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.DynamicForms.Helpers {
    public static class StringExtensions {
        public static string WithDefault(this string value, string defaultValue) {
            return !String.IsNullOrWhiteSpace(value) ? value : defaultValue;
        }
    }
}
