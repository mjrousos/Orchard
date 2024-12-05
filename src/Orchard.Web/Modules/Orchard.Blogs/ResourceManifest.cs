using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.UI.Resources;

namespace Orchard.Blogs {
    public class ResourceManifest : IResourceManifestProvider {
        public void BuildManifests(ResourceManifestBuilder builder) {
            var manifest = builder.Add();
            manifest.DefineStyle("BlogsAdmin")
                .SetUrl("orchard-blogs-admin.min.css", "orchard-blogs-admin.css");
            manifest.DefineStyle("BlogsArchives")
                .SetUrl("orchard-blogs-archives.min.css", "orchard-blogs-archives.css");
            manifest.DefineScript("BlogsArchives")
                .SetUrl("orchard-blogs-archives.min.js", "orchard-blogs-archives.js")
                .SetDependencies("jQuery");
        }
    }
}
