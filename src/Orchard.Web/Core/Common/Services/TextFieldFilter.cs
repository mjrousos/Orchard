using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Web;
using Orchard.Utility.Extensions;

namespace Orchard.Core.Common.Services {
    public class TextFieldFilter : HtmlFilter {
        public override string ProcessContent(string text, HtmlFilterContext context) {
            // Flavor is null for a normal input/text field
            return context.Flavor == null || String.Equals(context.Flavor, "textarea", StringComparison.OrdinalIgnoreCase) ? ReplaceNewLines(text) : text;
        }
        private static string ReplaceNewLines(string text) {
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            return HttpUtility.HtmlEncode(text).ReplaceNewLinesWith("<br />");
    }
} 
