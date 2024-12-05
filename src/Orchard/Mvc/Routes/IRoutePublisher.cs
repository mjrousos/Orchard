using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orchard.Mvc.Routes {
    public interface IRoutePublisher : IDependency {
        void Publish(IEnumerable<RouteDescriptor> routes, Func<IDictionary<string, object>, Task> pipeline = null);
    }
}
