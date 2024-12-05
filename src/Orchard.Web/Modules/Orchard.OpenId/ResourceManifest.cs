using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.UI.Resources;

namespace Orchard.OpenId
{
    public class ResourceManifest : IResourceManifestProvider
    {
        public void BuildManifests(ResourceManifestBuilder builder)
        {
            var manifest = builder.Add();
            manifest.DefineStyle("TwitterAdmin").SetUrl("twitter-admin.css");
            manifest.DefineScript("TwitterAdmin").SetUrl("twitter-admin.js");
        }
    }
}
