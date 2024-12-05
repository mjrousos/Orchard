using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;

namespace Orchard.Azure.MediaServices.Infrastructure.Assets {
    public class AssetDriverResult {
        public LocalizedString TabTitle { get; set; }
        public dynamic EditorShape { get; set; }
    }
}
