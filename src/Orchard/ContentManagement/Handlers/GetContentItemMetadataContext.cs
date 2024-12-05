using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.Logging;

namespace Orchard.ContentManagement.Handlers {
    public class GetContentItemMetadataContext {
        public ContentItem ContentItem { get; set; }
        public ContentItemMetadata Metadata { get; set; }
        public ILogger Logger { get; set; }
    }
}
