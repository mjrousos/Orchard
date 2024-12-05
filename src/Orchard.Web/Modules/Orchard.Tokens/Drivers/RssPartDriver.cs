using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement.Drivers;
using Orchard.Environment.Extensions;
using Orchard.Tokens.Models;

namespace Orchard.Tokens.Drivers {
    [OrchardFeature("Orchard.Tokens.Feeds")]
    public class RssPartDriver : ContentPartDriver<RssPart> {
    }
}
