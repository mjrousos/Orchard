using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Recipes.Models;

namespace Orchard.Recipes.ViewModels {
    public class RecipeResultViewModel {
        public RecipeResult Result { get; set; }
    }
}
