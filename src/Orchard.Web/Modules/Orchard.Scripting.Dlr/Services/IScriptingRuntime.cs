using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Microsoft.Scripting.Hosting;

namespace Orchard.Scripting.Dlr.Services {
    public interface IScriptingRuntime : ISingletonDependency {
        ScriptScope CreateScope();
        dynamic ExecuteExpression(string expression, ScriptScope scope);
        void ExecuteFile(string fileName, ScriptScope scope);
    }
}
