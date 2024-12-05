using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Layouts.ViewModels {
    public class LayoutEditorPropertiesItem {
        public string Label { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
    }
}
