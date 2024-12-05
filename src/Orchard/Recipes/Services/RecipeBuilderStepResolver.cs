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
using System.Text;
using System.Threading.Tasks;

namespace Orchard.Recipes.Services
{
    public class RecipeBuilderStepResolver : IRecipeBuilderStepResolver
    {
        private readonly IEnumerable<IRecipeBuilderStep> _recipeBuilderSteps;
        public RecipeBuilderStepResolver(IEnumerable<IRecipeBuilderStep> recipeBuilderSteps) {
            _recipeBuilderSteps = recipeBuilderSteps;
        }
        public IRecipeBuilderStep Resolve(string exportStepName) {
           return _recipeBuilderSteps.SingleOrDefault(x => x.Name == exportStepName);
        public IEnumerable<IRecipeBuilderStep> Resolve(IEnumerable<string> exportStepNames) {
            return from name in exportStepNames
                let provider = _recipeBuilderSteps.SingleOrDefault(x => x.Name == name)
                where provider != null
                select provider;
    }
}
