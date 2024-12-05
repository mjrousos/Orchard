using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.UI.Resources;

namespace Orchard.ContentPicker {
    public class ResourceManifest : IResourceManifestProvider {
        public void BuildManifests(ResourceManifestBuilder builder) {
            var manifest = builder.Add();
            manifest.DefineScript("ContentPicker").SetUrl("ContentPicker.js", "ContentPicker.js").SetDependencies("jQuery");
            manifest.DefineScript("SelectableContentTab").SetUrl("SelectableContentTab.js?v=1.1", "SelectableContentTab.js?v=1.1").SetDependencies("jQuery");
        }
    }
}
