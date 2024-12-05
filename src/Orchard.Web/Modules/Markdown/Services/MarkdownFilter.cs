using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Markdown.Services
{
    public class MarkdownFilter : HtmlFilter {
        public override string ProcessContent(string text, HtmlFilterContext context) {
            return String.Equals(context.Flavor, "markdown", StringComparison.OrdinalIgnoreCase) ? MarkdownReplace(text) : text;
        }
        private static string MarkdownReplace(string text) {
            if (String.IsNullOrEmpty(text))
                return String.Empty;
            return Markdig.Markdown.ToHtml(text);
    }
}
