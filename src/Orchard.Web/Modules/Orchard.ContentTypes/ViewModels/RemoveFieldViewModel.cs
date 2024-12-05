using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.ContentTypes.ViewModels {
    public class RemoveFieldViewModel {
        public string Name { get; set; }
        public EditPartViewModel Part { get; set; }
    }
}
