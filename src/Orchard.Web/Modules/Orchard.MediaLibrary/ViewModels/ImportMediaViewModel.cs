using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.MediaLibrary.Models;

namespace Orchard.MediaLibrary.ViewModels {
    public class ImportMediaViewModel {
        public string FolderPath { get; set; }
        public string Type { get; set; }
        public MediaPart Replace { get; set; }
    }
}
