using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;

namespace Orchard.Localization.Services {
    public class DefaultCultureFilter : ICultureFilter {
        public IContentQuery<ContentItem> FilterCulture(IContentQuery<ContentItem> query, string cultureName) {
            return query;
        }
    }
}
