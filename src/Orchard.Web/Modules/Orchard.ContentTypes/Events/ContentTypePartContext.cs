using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.ContentTypes.Events {
    public class ContentTypePartContext {
        public string ContentTypeName { get; set; }
        public string ContentPartName { get; set; }
    }
}
