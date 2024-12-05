using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.Azure.MediaServices.Models.Assets;

namespace Orchard.Azure.MediaServices.Services.Assets {
    public class AssetFactory : IAssetFactory {
        public Asset Create(string typeName) {
            var type = Type.GetType(typeName);
            return (Asset)Activator.CreateInstance(type);
        }
    }
}
