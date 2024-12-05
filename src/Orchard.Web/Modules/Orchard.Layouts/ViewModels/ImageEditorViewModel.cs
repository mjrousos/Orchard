using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.MediaLibrary.Models;

namespace Orchard.Layouts.ViewModels {
    public class ImageEditorViewModel {
        public string ImageId { get; set; }
        public ImagePart CurrentImage { get; set; }
    }
}
