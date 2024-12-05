using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.Recipes.Services
{
    public interface IRecipeBuilderStepResolver : IDependency
    {
        IRecipeBuilderStep Resolve(string exportStepName);
        IEnumerable<IRecipeBuilderStep> Resolve(IEnumerable<string> exportStepNames);
    }
}
