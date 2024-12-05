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

namespace Orchard.Templates.Compilation.Razor {
    public interface IRazorCompiler : IDependency {
        IRazorTemplateBase<TModel> CompileRazor<TModel>(string code, string name, IDictionary<string, object> parameters);
        IRazorTemplateBase CompileRazor(string code, string name, IDictionary<string, object> parameters);
    }
}
