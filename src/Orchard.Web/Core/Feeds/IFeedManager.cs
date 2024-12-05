using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using System.Web.Routing;

namespace Orchard.Core.Feeds {
    public interface IFeedManager : IDependency {
        void Register(string title, string format, RouteValueDictionary values);
        void Register(string title, string format, string url);
        MvcHtmlString GetRegisteredLinks(HtmlHelper html);
        
        // Currently implemented in FeedController action... tbd
        //ActionResult Execute(string format, IValueProvider values);
    }
}
