using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.MediaLibrary.Models;

namespace Orchard.MediaLibrary.ViewModels {
    public class MediaManagerChildFoldersViewModel {
        public IEnumerable<IMediaFolder> Children { get; set; }
    }
}
