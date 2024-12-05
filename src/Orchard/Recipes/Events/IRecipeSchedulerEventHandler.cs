using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Events;

namespace Orchard.Recipes.Events {
    public interface IRecipeSchedulerEventHandler : IEventHandler  {
        void ExecuteWork(string executionId);
    }
}
