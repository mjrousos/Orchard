using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Xml;
using System.Xml.Linq;

namespace Orchard.Core.Feeds.Rss {
    public class RssResult : ActionResult {
        public XDocument Document { get; private set; }
        public RssResult(XDocument document) {
            Document = document;
        }
        public override void ExecuteResult(ControllerContext context) {
                
            // not returning application/rss+xml because of
            // https://bugzilla.mozilla.org/show_bug.cgi?id=256379
            context.HttpContext.Response.ContentType = "text/xml";
            using (var writer = XmlWriter.Create(context.HttpContext.Response.Output))
                Document.WriteTo(writer);
    }
}
