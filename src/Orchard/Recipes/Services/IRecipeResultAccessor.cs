using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Recipes.Models;

namespace Orchard.Recipes.Services {
    /// <summary>
    /// Provides information about the result of recipe execution.
    /// </summary>
    public interface IRecipeResultAccessor : IDependency {
        RecipeResult GetResult(string executionId);
    }
}
