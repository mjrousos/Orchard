using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Recipes.Services {
    public interface IRecipeStepExecutor : IDependency {
        bool ExecuteNextStep(string executionId);
    }
}
