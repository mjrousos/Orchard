using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Environment.Extensions.Models;
using Orchard.Recipes.Models;

namespace Orchard.Packaging.ViewModels {
    public class PackagingInstallViewModel {
        public List<PackagingInstallFeatureViewModel> Features { get; set; }
        public List<PackagingInstallRecipeViewModel> Recipes { get; set; }
        public ExtensionDescriptor ExtensionDescriptor { get; set; }
    }
    public class PackagingInstallFeatureViewModel {
        public FeatureDescriptor FeatureDescriptor { get; set; }
        public bool Enable { get; set; }
    public class PackagingInstallRecipeViewModel {
        public Recipe Recipe { get; set; }
        public bool Execute { get; set; }
}
