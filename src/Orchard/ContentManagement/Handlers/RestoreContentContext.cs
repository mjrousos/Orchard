using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
namespace Orchard.ContentManagement.Handlers {
    public class RestoreContentContext : ContentContextBase {
        public VersionOptions VersionOptions { get; set; }

        public RestoreContentContext(ContentItem contentItem, VersionOptions versionOptions) : base(contentItem) {
            VersionOptions = versionOptions;
        }
    }
}
