using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.UI.Resources;

namespace Orchard.Tags {
    public class ResourceManifest : IResourceManifestProvider {
        public void BuildManifests(ResourceManifestBuilder builder) {
            var manifest = builder.Add();
            manifest.DefineScript("TagsAutocomplete").SetUrl("orchard-tags-autocomplete.js").SetDependencies("jQueryUI");
            manifest.DefineStyle("TagsAdmin").SetUrl("orchard-tags-admin.css");
        }
    }
}
