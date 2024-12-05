using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.Mvc;

namespace Orchard.Themes.Preview {
    public class PreviewTheme : IPreviewTheme {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static readonly string PreviewThemeKey = typeof(PreviewTheme).FullName;
        public PreviewTheme(IHttpContextAccessor httpContextAccessor) {
            _httpContextAccessor = httpContextAccessor;
        }
        public string GetPreviewTheme() {
            var httpContext = _httpContextAccessor.Current();
            if (httpContext.Session != null) {
                return Convert.ToString(httpContext.Session[PreviewThemeKey]);
            }
            return null;
        public void SetPreviewTheme(string themeName) {
                if (string.IsNullOrEmpty(themeName)) {
                    httpContext.Session.Remove(PreviewThemeKey);
                }
                else {
                    httpContext.Session[PreviewThemeKey] = themeName;
    }
}
