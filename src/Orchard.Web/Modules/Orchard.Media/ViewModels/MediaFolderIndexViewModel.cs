using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Media.Models;

namespace Orchard.Media.ViewModels {
    public class MediaFolderIndexViewModel {
        public IEnumerable<MediaFolder> MediaFolders { get; set; }
    }
}
