using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.UI.Resources;

namespace Orchard.Resources {
    public class Knockout : IResourceManifestProvider {
        public void BuildManifests(ResourceManifestBuilder builder) {
            var manifest = builder.Add();
            manifest.DefineScript("Knockout").SetUrl("knockout.min.js", "knockout.js").SetVersion("3.4.0"); // TODO: Set the CDN URL as soon as its available on the AJAXCDN site for this version.
        }
    }
}
