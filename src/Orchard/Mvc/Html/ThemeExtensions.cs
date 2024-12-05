using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web.Mvc;
using System.Web.Mvc.Html;
using Orchard.Environment.Extensions.Models;
using Orchard.Validation;

namespace Orchard.Mvc.Html {
    public static class ThemeExtensions {
        /// <summary>
        /// Include a view from the current view.
        /// </summary>
        public static void Include(this HtmlHelper helper, string viewName) {
            Argument.ThrowIfNull(helper, "helper");
            helper.RenderPartial(viewName);
        }
        public static string ThemePath(this HtmlHelper helper, ExtensionDescriptor theme, string path) {
            return theme.Location + "/" + theme.Id + path;
    }
}
