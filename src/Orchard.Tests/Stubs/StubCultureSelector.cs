using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web;
using Orchard.Localization.Services;

namespace Orchard.Tests.Stubs {
    public class StubCultureSelector : ICultureSelector {
        private readonly string _cultureName;
        public StubCultureSelector(string cultureName) {
            _cultureName = cultureName;
        }
        public CultureSelectorResult GetCulture(HttpContextBase context) {
            return new CultureSelectorResult { Priority = 1, CultureName = _cultureName };
    }
}
