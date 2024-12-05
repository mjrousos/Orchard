using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.UI.Resources;

namespace Orchard.DynamicForms {
    public class ResourceManifest : IResourceManifestProvider {
        public void BuildManifests(ResourceManifestBuilder builder) {
            var manifest = builder.Add();
            manifest.DefineStyle("DynamicForms.FormElements").SetUrl("DynamicForms-Admin.min.css", "DynamicForms-Admin.css");
            manifest.DefineScript("DynamicForms.FormElements").SetUrl("LayoutEditor.min.js", "LayoutEditor.js").SetDependencies("Layouts.LayoutEditor");
        }
    }
}
