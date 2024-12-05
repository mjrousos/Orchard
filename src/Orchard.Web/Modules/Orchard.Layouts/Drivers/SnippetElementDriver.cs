using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Environment.Extensions;
using Orchard.Layouts.Elements;
using Orchard.Layouts.Framework.Drivers;

namespace Orchard.Layouts.Drivers {
    [OrchardFeature("Orchard.Layouts.Snippets")]
    public class SnippetElementDriver : ElementDriver<Snippet> {
    }
}
