using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;

namespace Orchard.ContentPreview.Drivers {
    public class ContentPreviewDriver : ContentPartDriver<ContentPart> {
        protected override DriverResult Editor(ContentPart part, dynamic shapeHelper) =>
            ContentShape("ContentPreview_Button", () => shapeHelper.ContentPreview_Button(Model: part.ContentItem));
    }
}
