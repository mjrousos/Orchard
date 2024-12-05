using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement.Drivers;
using Orchard.MediaLibrary.Models;

namespace Orchard.ImageEditor.Drivers {
    public class ImagePartDriver : ContentPartDriver<ImagePart> {
        protected override DriverResult Display(ImagePart part, string displayType, dynamic shapeHelper) {
            return ContentShape("Parts_Image_Editor", () => shapeHelper.Parts_Image_Editor());
        }
    }
}
