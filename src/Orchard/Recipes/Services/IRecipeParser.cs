using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Xml.Linq;
using Orchard.Recipes.Models;

namespace Orchard.Recipes.Services {
    public interface IRecipeParser : IDependency {
        Recipe ParseRecipe(XDocument recipeDocument);
    }
    public static class RecipeParserExtensions {
        public static Recipe ParseRecipe(this IRecipeParser recipeParser, string recipeText) {
            var recipeDocument = XDocument.Parse(recipeText, LoadOptions.PreserveWhitespace);
            return recipeParser.ParseRecipe(recipeDocument);
        }
}
