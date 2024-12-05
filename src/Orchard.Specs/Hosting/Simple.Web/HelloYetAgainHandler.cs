using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Web;
using System.Web.Routing;

namespace Orchard.Specs.Hosting.Orchard.Web
{
    public class HelloYetAgainHandler : IRouteHandler, IHttpHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return this;
        }
        public void ProcessRequest(HttpContext context)
            context.Response.Write("Hello yet again");
        public bool IsReusable { get { return false; } }
    }
}
