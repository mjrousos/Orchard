using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.UI.Resources;

namespace Orchard.Autoroute {
    public class ResourceManifest : IResourceManifestProvider {
        public void BuildManifests(ResourceManifestBuilder builder) {
            var manifest = builder.Add();
            manifest.DefineStyle("AutorouteSettings").SetUrl("orchard-autoroute-settings.css");
            manifest.DefineScript("AutorouteBrowser").SetUrl("autoroute-browser.js").SetDependencies("jQuery");
        }
    }
}
