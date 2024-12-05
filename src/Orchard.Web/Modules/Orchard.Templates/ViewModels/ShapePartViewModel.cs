using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Templates.Models;

namespace Orchard.Templates.ViewModels {
    public class ShapePartViewModel {
        public string Template { get; set; }
        public RenderingMode RenderingMode { get; set; }
    }
}
