using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web.Routing;

namespace Orchard.Autoroute.Services {
    
    public interface IHomeAliasService : IDependency {
        RouteValueDictionary GetHomeRoute();
        int? GetHomePageId(VersionOptions version = null);
        IContent GetHomePage(VersionOptions version = null);
        bool IsHomePage(IContent content, VersionOptions homePageVersion = null);
        void PublishHomeAlias(IContent content);
        void PublishHomeAlias(string route);
        void PublishHomeAlias(RouteValueDictionary route);
    }
}
