using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.Indexing;

namespace Orchard.ContentManagement.Handlers {
    public class IndexContentContext : ContentContextBase {
        public IDocumentIndex DocumentIndex { get; private set; }
        public IndexContentContext(ContentItem contentItem, IDocumentIndex documentIndex)
            : base(contentItem) {
            DocumentIndex = documentIndex;
        }
    }
}
