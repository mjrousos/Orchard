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
    public interface ICultureFilter : IDependency {
        IContentQuery<ContentItem> FilterCulture(IContentQuery<ContentItem> query, string cultureName);
    }
}
