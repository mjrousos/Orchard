using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;

namespace Orchard.Themes.Models {
    /// <summary>
    /// When attached to a Content Type and rendered 
    /// it will prevent the theme from being applied
    /// </summary>
    public class DisableThemePart : ContentPart {
    }
}
