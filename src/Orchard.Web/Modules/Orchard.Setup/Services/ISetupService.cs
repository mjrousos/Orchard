using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Environment.Configuration;
using Orchard.Recipes.Models;

namespace Orchard.Setup.Services {
    public interface ISetupService : IDependency {
        ShellSettings Prime();
        IEnumerable<Recipe> Recipes();
        string Setup(SetupContext context);
    }
}
