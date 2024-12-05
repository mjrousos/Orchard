using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.Environment.Extensions.Models {
    public static class DefaultExtensionTypes {
        public const string Module = "Module";
        public const string Theme = "Theme";
        public static bool IsModule(string extensionType) {
            return string.Equals(extensionType, Module, StringComparison.OrdinalIgnoreCase);
        }
        public static bool IsTheme(string extensionType) {
            return string.Equals(extensionType, Theme, StringComparison.OrdinalIgnoreCase);
    }
}
