using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Layouts.Elements;
using Orchard.Layouts.Framework.Display;
using Orchard.Layouts.Framework.Drivers;

namespace Orchard.Layouts.Drivers {
    public class ColumnElementDriver : ElementDriver<Column> {
        protected override void OnDisplaying(Column element, ElementDisplayingContext context) {
            context.ElementShape.Width = element.Width;
            context.ElementShape.Offset = element.Offset;
            context.ElementShape.Collapsed = false;
        }
    }
}
