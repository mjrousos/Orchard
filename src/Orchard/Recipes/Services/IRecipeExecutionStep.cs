using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Recipes.Models;

namespace Orchard.Recipes.Services {
    public interface IRecipeExecutionStep : IDependency {
        string Name { get; }
        IEnumerable<string> Names { get; }
        LocalizedString DisplayName { get; }
        LocalizedString Description { get; }
        dynamic BuildEditor(dynamic shapeFactory);
        dynamic UpdateEditor(dynamic shapeFactory, IUpdateModel updater);
        void Configure(RecipeExecutionStepConfigurationContext context);
        void UpdateStep(UpdateRecipeExecutionStepContext context);
        void Execute(RecipeExecutionContext context);
        
    }
}
