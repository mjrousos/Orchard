using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.Settings {
    public class CurrentSiteWorkContext : IWorkContextStateProvider {
        private readonly ISiteService _siteService;
        public CurrentSiteWorkContext(ISiteService siteService) {
            _siteService = siteService;
        }
        public Func<WorkContext, T> Get<T>(string name) {
            if (name == "CurrentSite") {
                var siteSettings = _siteService.GetSiteSettings();
                return ctx => (T)siteSettings;
            }
            return null;
    }
}
