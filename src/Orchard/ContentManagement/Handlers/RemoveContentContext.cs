using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
namespace Orchard.ContentManagement.Handlers {
    public class RemoveContentContext : ContentContextBase {
        public RemoveContentContext(ContentItem contentItem) : base(contentItem) {
        }
    }
}
