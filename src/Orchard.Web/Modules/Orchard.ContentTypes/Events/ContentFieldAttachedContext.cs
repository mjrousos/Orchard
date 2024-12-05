using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.ContentTypes.Events {
    public class ContentFieldAttachedContext : ContentPartFieldContext {
        public string ContentFieldTypeName { get; set; }
        public string ContentFieldDisplayName { get; set; }
    }
}
