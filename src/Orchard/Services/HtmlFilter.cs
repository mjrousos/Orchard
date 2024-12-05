using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Services {
    public abstract class HtmlFilter : Component, IHtmlFilter {
        public abstract string ProcessContent(string text, HtmlFilterContext context);
    }
}
