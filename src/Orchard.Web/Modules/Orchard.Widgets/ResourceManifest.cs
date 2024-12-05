using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.UI.Resources;

namespace Orchard.Widgets {
    public class ResourceManifest : IResourceManifestProvider {
        public void BuildManifests(ResourceManifestBuilder builder) {
            builder.Add().DefineStyle("WidgetsAdmin").SetUrl("orchard-widgets-admin.css").SetDependencies("~/Themes/TheAdmin/Styles/Site.css");
        }
    }
}
