using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using Orchard.Recipes.Models;

namespace Orchard.Recipes.Services {
    public interface IRecipeHarvester : IDependency {
        /// <summary>
        /// Returns a collection of all recipes.
        /// </summary>
        IEnumerable<Recipe> HarvestRecipes();
        /// Returns a collection of all recipes found in the specified extension.
        IEnumerable<Recipe> HarvestRecipes(string extensionId);
    }
    public static class RecipeHarvesterExtensions {
        public static Recipe GetRecipeByName(this IEnumerable<Recipe> recipes, string recipeName) {
            return recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
        }
}
