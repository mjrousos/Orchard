using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Web.Routing;

namespace Orchard.Themes.Services {
    public class SiteThemeSelector : IThemeSelector {
        private readonly ISiteThemeService _siteThemeService;
        public SiteThemeSelector(ISiteThemeService siteThemeService) {
            _siteThemeService = siteThemeService;
        }
        public ThemeSelectorResult GetTheme(RequestContext context) {
            string currentThemeName = _siteThemeService.GetCurrentThemeName();
            return String.IsNullOrEmpty(currentThemeName) ? null : new ThemeSelectorResult { Priority = -5, ThemeName = currentThemeName };
    }
}
