using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.ContentTypes.ViewModels {
    public class ContentTypeSettingsViewModel {
        public bool Creatable { get; set; }
        public bool Listable { get; set; }
        public bool Draftable { get; set; }
        public bool Securable { get; set; }
        public string Stereotype { get; set; }
    }
}
