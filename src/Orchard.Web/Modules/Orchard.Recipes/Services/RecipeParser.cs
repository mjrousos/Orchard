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
using System.Globalization;
using System.Xml;
using System.Xml.Linq;
using Orchard.Logging;
using Orchard.Recipes.Models;

namespace Orchard.Recipes.Services {
    public class RecipeParser : Component, IRecipeParser {
        public Recipe ParseRecipe(XDocument recipeDocument) {
            var recipe = new Recipe();
            var recipeSteps = new List<RecipeStep>();
            var stepId = 0;
            foreach (var element in recipeDocument.Root.Elements()) {
                // Recipe metadata.
                if (element.Name.LocalName == "Recipe") {
                    foreach (var metadataElement in element.Elements()) {
                        switch (metadataElement.Name.LocalName) {
                            case "Name":
                                recipe.Name = metadataElement.Value;
                                break;
                            case "Description":
                                recipe.Description = metadataElement.Value;
                            case "Author":
                                recipe.Author = metadataElement.Value;
                            case "WebSite":
                                recipe.WebSite = metadataElement.Value;
                            case "Version":
                                recipe.Version = metadataElement.Value;
                            case "IsSetupRecipe":
                                recipe.IsSetupRecipe = !string.IsNullOrEmpty(metadataElement.Value) ? bool.Parse(metadataElement.Value) : false;
                            case "ExportUtc":
                                recipe.ExportUtc = !string.IsNullOrEmpty(metadataElement.Value) ? (DateTime?)XmlConvert.ToDateTime(metadataElement.Value, XmlDateTimeSerializationMode.Utc) : null;
                            case "Category":
                                recipe.Category = metadataElement.Value;
                            case "Tags":
                                recipe.Tags = metadataElement.Value;
                            default:
                                Logger.Warning("Unrecognized recipe metadata element '{0}' encountered; skipping.", metadataElement.Name.LocalName);
                        }
                    }
                }
                // Recipe step.
                else {
                    var recipeStep = new RecipeStep(id: (++stepId).ToString(CultureInfo.InvariantCulture), recipeName: recipe.Name, name: element.Name.LocalName, step: element );
                    recipeSteps.Add(recipeStep);
            }
            recipe.RecipeSteps = recipeSteps;
            return recipe;
        }
    }
}
