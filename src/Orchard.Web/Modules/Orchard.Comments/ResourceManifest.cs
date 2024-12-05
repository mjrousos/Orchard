using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.UI.Resources;

namespace Orchard.Comments {
    public class ResourceManifest : IResourceManifestProvider {
        public void BuildManifests(ResourceManifestBuilder builder) {
            var manifest = builder.Add();
            manifest.DefineStyle("Admin").SetUrl("orchard-comments-admin.css");
            manifest.DefineScript("Comments.Threaded")
                .SetUrl("Orchard.Comments.Threaded.min.js", "Orchard.Comments.Threaded.js").SetDependencies("jQuery");
        }
    }
}
