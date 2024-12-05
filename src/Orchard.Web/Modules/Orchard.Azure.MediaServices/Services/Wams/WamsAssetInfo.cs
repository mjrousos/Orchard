using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Azure.MediaServices.Services.Wams {
    public class WamsAssetInfo {
        public string SasLocator { get; set; }
        public string AssetId { get; set; }
    }
}
