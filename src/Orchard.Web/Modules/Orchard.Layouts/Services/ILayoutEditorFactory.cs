using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;
using Orchard.Layouts.Models;
using Orchard.Layouts.ViewModels;

namespace Orchard.Layouts.Services {
    public interface ILayoutEditorFactory : IDependency {
        LayoutEditor Create(LayoutPart layoutPart);
        LayoutEditor Create(string layoutData, string sessionKey, int? templateId = null, IContent content = null);
    }
}
