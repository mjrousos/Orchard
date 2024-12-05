using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.Design;

namespace System.Web.Mvc
{
    public abstract class Controller : Microsoft.AspNetCore.Mvc.Controller
    {
        protected internal new ViewResult View()
        {
            return base.View();
        }

        protected internal new ViewResult View(object model)
        {
            return base.View(model);
        }

        protected internal new ViewResult View(string viewName)
        {
            return base.View(viewName);
        }

        protected internal new ViewResult View(string viewName, object model)
        {
            return base.View(viewName, model);
        }
    }

    public class ControllerContext
    {
        private readonly Microsoft.AspNetCore.Mvc.ControllerContext _coreContext;

        public ControllerContext(Microsoft.AspNetCore.Mvc.ControllerContext context)
        {
            _coreContext = context;
        }

        public HttpContextBase HttpContext => new HttpContextWrapper(_coreContext.HttpContext);
        public RouteData RouteData => new RouteData(_coreContext.RouteData);
    }

    public class RouteData
    {
        private readonly Microsoft.AspNetCore.Routing.RouteData _coreRouteData;

        public RouteData(Microsoft.AspNetCore.Routing.RouteData routeData)
        {
            _coreRouteData = routeData;
        }

        public string GetRequiredString(string key)
        {
            return _coreRouteData.Values[key]?.ToString() ?? throw new InvalidOperationException($"Route value for '{key}' not found.");
        }
    }

    public class RouteCollection
    {
        private readonly Microsoft.AspNetCore.Routing.RouteCollection _coreRouteCollection;
        private readonly IInlineConstraintResolver _constraintResolver;

        public RouteCollection()
        {
            _coreRouteCollection = new Microsoft.AspNetCore.Routing.RouteCollection();
            var services = new ServiceContainer();
            _constraintResolver = new DefaultInlineConstraintResolver(
                new OptionsManager<RouteOptions>(
                    new OptionsFactory<RouteOptions>(
                        new List<IConfigureOptions<RouteOptions>>(),
                        new List<IPostConfigureOptions<RouteOptions>>()
                    )
                ),
                services
            );
        }

        public void MapRoute(string name, string template)
        {
            var defaults = new RouteValueDictionary();
            var constraints = new Dictionary<string, object>();
            var dataTokens = new RouteValueDictionary();
            _coreRouteCollection.Add(new Route(
                new RouteHandler(context => Task.CompletedTask),
                template,
                defaults,
                constraints,
                dataTokens,
                _constraintResolver));
        }
    }
}
