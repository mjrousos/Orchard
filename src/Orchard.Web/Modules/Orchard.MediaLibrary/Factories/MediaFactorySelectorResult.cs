using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.MediaLibrary.Factories {
    public class MediaFactorySelectorResult {
        public int Priority { get; set; }
        public IMediaFactory MediaFactory { get; set; }
    }
}
