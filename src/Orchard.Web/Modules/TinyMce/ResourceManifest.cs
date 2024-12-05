using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.UI.Resources;

namespace TinyMce {
    public class ResourceManifest : IResourceManifestProvider {
        public void BuildManifests(ResourceManifestBuilder builder) {
            var manifest = builder.Add();
            manifest.DefineScript("TinyMce").SetUrl("tinymce.min.js", "tinymce.js").SetVersion("4.8.3").SetDependencies("jQuery");
            manifest.DefineScript("OrchardTinyMce").SetUrl("orchard-tinymce.js").SetDependencies("TinyMce");
            manifest.DefineStyle("OrchardTinyMce").SetUrl("orchard-tinymce.css");
        }
    }
}
