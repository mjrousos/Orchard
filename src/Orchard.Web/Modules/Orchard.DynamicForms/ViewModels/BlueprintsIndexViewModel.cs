using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.DynamicForms.Models;
using Orchard.Layouts.Models;

namespace Orchard.DynamicForms.ViewModels {
    public class BlueprintsIndexViewModel {
        public IList<ElementBlueprint> Blueprints { get; set; }
    }
}
