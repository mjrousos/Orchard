using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.Azure.MediaServices.ViewModels.Media {
    public class AssetUploadViewModel {
        public IList<string> AllowedVideoFilenameExtensions { get; set; }
    }
}
