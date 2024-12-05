using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.Scripting {
    public interface IScriptExpressionEvaluator : ISingletonDependency {
        object Evaluate(string expression, IEnumerable<IGlobalMethodProvider> providers);
    }
}
