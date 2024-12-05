using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
namespace Orchard.ContentManagement.Handlers {
    public class ActivatedContentContext {
        public string ContentType { get; set; }
        public ContentItem ContentItem { get; set; }
    }
}
