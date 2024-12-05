using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;

namespace Orchard.Layouts.Models {
    public interface ILayoutAspect : IContent {
        int? TemplateId { get; set; }
        string LayoutData { get; set; }
    }
}
