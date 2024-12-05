using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web.Routing;
using Orchard.Themes;

namespace Orchard.UI.Admin {
    public class AdminThemeSelector : IThemeSelector {
        public ThemeSelectorResult GetTheme(RequestContext context) {
            if (AdminFilter.IsApplied(context)) {
                return new ThemeSelectorResult { Priority = 100, ThemeName = "TheAdmin" };
            }
            return null;
        }
    }
}
