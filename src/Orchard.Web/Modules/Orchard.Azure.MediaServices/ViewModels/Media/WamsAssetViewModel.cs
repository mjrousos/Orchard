using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Azure.MediaServices.ViewModels.Media {
    public class WamsAssetViewModel {
        public string FileName { get; set; }
        public string WamsAssetId { get; set; }
        public int? AssetId { get; set; }
    }
}
