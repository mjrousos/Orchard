using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Modules.ViewModels {
    public class FeatureStepViewModel {
        public bool ExportEnabledFeatures { get; set; }
        public bool ExportDisabledFeatures { get; set; }
    }
}
