using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;
using System.Web.Routing;

namespace Orchard.UI.Navigation {
    public interface INavigationManager : IDependency {
        IEnumerable<MenuItem> BuildMenu(string menuName);
        IEnumerable<MenuItem> BuildMenu(IContent menu);
        IEnumerable<string> BuildImageSets(string menuName);
        string GetUrl(string menuItemUrl, RouteValueDictionary routeValueDictionary);
        string GetNextPosition(IContent menu);
    }
}
