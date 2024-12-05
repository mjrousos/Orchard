using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.UI.Resources;

namespace Orchard.Layouts {
    public class ResourceManifest : IResourceManifestProvider {
        public void BuildManifests(ResourceManifestBuilder builder) {
            var manifest = builder.Add();
            manifest.DefineScript("Layouts.Lib").SetDependencies("jQuery", "AngularJs_Full", "Underscore");
            manifest.DefineScript("Layouts.Models").SetUrl("Models.min.js", "Models.js").SetDependencies("jQuery", "Layouts.Lib");
            manifest.DefineScript("Layouts.LayoutEditor").SetUrl("LayoutEditor.min.js", "LayoutEditor.js").SetDependencies("jQuery", "Layouts.Lib", "Layouts.Models");
        }
    }
}
