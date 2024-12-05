using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Web.Caching;
using System.Web;
using System.Web.Hosting;

namespace Orchard.Mvc.ViewEngines.ThemeAwareness {
    public class ThemeViewLocationCache : IViewLocationCache {
        private readonly string _requestTheme;
        public ThemeViewLocationCache(string requestTheme) {
            _requestTheme = requestTheme;
        }
        private string AlterKey(string key) {
            return key + ":" + _requestTheme;
        public string GetViewLocation(HttpContextBase httpContext, string key) {
            if (httpContext == null) {
                throw new ArgumentNullException("httpContext");
            }
            return (string)httpContext.Cache[AlterKey(key)];
        public void InsertViewLocation(HttpContextBase httpContext, string key, string virtualPath) {
            httpContext.Cache.Insert(AlterKey(key), virtualPath, new CacheDependency(HostingEnvironment.MapPath("~/Themes")));
    }
}
