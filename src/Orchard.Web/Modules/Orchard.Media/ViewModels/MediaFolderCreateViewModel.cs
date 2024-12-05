using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Orchard.Media.ViewModels {
    public class MediaFolderCreateViewModel {
        [Required, DisplayName("Folder Name:")]
        public string Name { get; set; }
        public string MediaPath { get; set; }
    }
}
