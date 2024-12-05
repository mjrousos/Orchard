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
    public interface IRecipeBuilderStep : IDependency {
        string Name { get; }
        LocalizedString DisplayName { get; }
        LocalizedString Description { get; }
        /// <summary>
        /// The order in which this builder should execute.
        /// </summary>
        int Priority { get; }
        /// The order in which this builder should be displayed.
        int Position { get; }
        bool IsVisible { get; }
        dynamic BuildEditor(dynamic shapeFactory);
        dynamic UpdateEditor(dynamic shapeFactory, IUpdateModel updater);
        void Configure(RecipeBuilderStepConfigurationContext configurationElement);
        void ConfigureDefault();
        void Build(BuildContext context);
    }
}
