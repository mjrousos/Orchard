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
    public class VectorImageEditorViewModel {
        public string VectorImageId { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public VectorImagePart CurrentVectorImage { get; set; }
    }
}
