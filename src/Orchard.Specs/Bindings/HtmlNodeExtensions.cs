using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using HtmlAgilityPack;

namespace Orchard.Specs.Bindings {
    public static class HtmlNodeExtensions {
        public static string GetOptionValue(this HtmlNode node) {
            return node.Attributes.Contains("value")
                       ? node.GetAttributeValue("value", "")
                       : node.NextSibling != null && node.NextSibling.NodeType == HtmlNodeType.Text ? node.NextSibling.InnerText : "";
        }
    }
}
