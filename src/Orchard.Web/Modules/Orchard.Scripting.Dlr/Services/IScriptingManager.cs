using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Microsoft.Scripting.Hosting;

namespace Orchard.Scripting.Dlr.Services {
    public interface IScriptingManager : IDependency {
        dynamic GetVariable(string name);
        void SetVariable(string name, object value);
        dynamic ExecuteExpression(string expression);
        void ExecuteFile(string fileName);
        dynamic ExecuteOperation(Func<ObjectOperations, object> invoke);
    }
}
