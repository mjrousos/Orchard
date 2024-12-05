using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web;

namespace Orchard.Localization.Services {
    public class CultureSelectorResult {
        public int Priority { get; set; }
        public string CultureName { get; set; }
    }
    public interface ICultureSelector : IDependency {
        CultureSelectorResult GetCulture(HttpContextBase context);
}
