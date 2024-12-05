using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Localization;

namespace Orchard.ImportExport.ViewModels {
    public class RecipeExecutionStepViewModel {
        public string Name { get; set; }
        public LocalizedString DisplayName { get; set; }
        public LocalizedString Description { get; set; }
        public bool IsSelected { get; set; }
        public dynamic Editor { get; set; }
    }
}
