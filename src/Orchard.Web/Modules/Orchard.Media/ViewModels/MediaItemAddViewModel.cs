using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Media.ViewModels {
    public class MediaItemAddViewModel {
        public MediaItemAddViewModel() {
            ExtractZip = true;
        }

        public string FolderName { get; set; }
        public string MediaPath { get; set; }
        public bool ExtractZip { get; set; }
        public string AllowedExtensions { get; set; }
    }
}
