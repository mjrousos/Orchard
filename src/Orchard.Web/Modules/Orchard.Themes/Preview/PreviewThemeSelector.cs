using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web.Routing;

namespace Orchard.Themes.Preview {
    public class PreviewThemeSelector : IThemeSelector {
        private readonly IPreviewTheme _previewTheme;
        public PreviewThemeSelector(IPreviewTheme previewTheme) {
            _previewTheme = previewTheme;
        }
        public ThemeSelectorResult GetTheme(RequestContext context) {
            var previewThemeName = _previewTheme.GetPreviewTheme();
            return string.IsNullOrEmpty(previewThemeName) ? null : new ThemeSelectorResult { Priority = 90, ThemeName = previewThemeName };
    }
}
