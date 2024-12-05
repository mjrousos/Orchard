using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.UI.Navigation {
    public interface INavigationProvider : IDependency {
        string MenuName { get; }
        void GetNavigation(NavigationBuilder builder);
    }
}
