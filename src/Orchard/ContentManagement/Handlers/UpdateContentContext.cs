using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.ContentManagement.Records;

namespace Orchard.ContentManagement.Handlers {
    public class UpdateContentContext : ContentContextBase {
        public UpdateContentContext(ContentItem contentItem) : base(contentItem) {
            UpdatingItemVersionRecord = contentItem.VersionRecord;
        }
        public ContentItemVersionRecord UpdatingItemVersionRecord { get; set; }
    }
}
