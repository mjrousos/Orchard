using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;

namespace Orchard.DesignerTools.Models {
    public class ShapeTracingSiteSettingsPart : ContentPart {
        public bool IsShapeTracingActive
        {
            get { return this.Retrieve(x => x.IsShapeTracingActive); }
            set { this.Store(x => x.IsShapeTracingActive, value); }
        }
    }
}
