using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Recipes.Models {
    public class RecipeContext {
        public RecipeStep RecipeStep { get; set; }
        public bool Executed { get; set; }
        public string ExecutionId { get; set; }
    }
}
