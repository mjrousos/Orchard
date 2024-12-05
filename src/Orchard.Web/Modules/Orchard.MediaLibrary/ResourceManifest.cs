using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.UI.Resources;

namespace Orchard.MediaLibrary {
    public class ResourceManifest : IResourceManifestProvider {
        public void BuildManifests(ResourceManifestBuilder builder) {
            var manifest = builder.Add();
            manifest.DefineStyle("MediaManagerAdmin").SetUrl("orchard-medialibrary-admin.css").SetDependencies("~/Themes/TheAdmin/Styles/Site.css");
        }
    }
}
