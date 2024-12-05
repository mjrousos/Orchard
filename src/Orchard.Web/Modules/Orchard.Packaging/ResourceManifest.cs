using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.Environment.Extensions;
using Orchard.UI.Resources;

namespace Orchard.Packaging {
    [OrchardFeature("Gallery")]
    public class ResourceManifest : IResourceManifestProvider {
        public void BuildManifests(ResourceManifestBuilder builder) {
            UI.Resources.ResourceManifest resourceManifest = builder.Add();
            resourceManifest.DefineStyle("PackagingAdmin").SetUrl("orchard-packaging-admin.css");
        }
    }
}
