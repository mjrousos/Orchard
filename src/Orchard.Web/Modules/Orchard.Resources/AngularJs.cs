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
    public class AngularJs : IResourceManifestProvider {
        public void BuildManifests(ResourceManifestBuilder builder) {
            var manifest = builder.Add();
            manifest.DefineScript("AngularJs").SetUrl("angular.min.js", "angular.js").SetVersion("1.3.3");
            manifest.DefineScript("AngularJs_Sanitize").SetUrl("angular-sanitize.min.js", "angular-sanitize.js").SetVersion("1.3.3").SetDependencies("AngularJs");
            manifest.DefineScript("AngularJs_Resource").SetUrl("angular-resource.min.js", "angular-resource.js").SetVersion("1.3.3").SetDependencies("AngularJs");
            manifest.DefineScript("AngularJs_Sortable").SetUrl("angular-sortable.min.js", "angular-sortable.js").SetDependencies("AngularJs", "jQueryUI_Sortable");
            manifest.DefineScript("AngularJs_Full").SetDependencies("AngularJs", "AngularJs_Sanitize", "AngularJs_Resource", "AngularJs_Sortable");
        }
    }
}
