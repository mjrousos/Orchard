using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.UI.Resources;

namespace Orchard.ContentTypes {
    public class ResourceManifest : IResourceManifestProvider {
        public void BuildManifests(ResourceManifestBuilder builder) {
            builder.Add().DefineStyle("ContentTypesAdmin").SetUrl("orchard-contenttypes-admin.css");
            builder.Add().DefineScript("PlacementEditor")
                .SetUrl("admin-placementeditor.js")
                .SetDependencies("jQueryUI_Sortable");
        }
    }
}
