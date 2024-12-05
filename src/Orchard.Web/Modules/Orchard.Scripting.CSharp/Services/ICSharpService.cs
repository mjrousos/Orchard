using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.Scripting.CSharp.Services {
    public interface ICSharpService : IDependency {
        void SetParameter(string name, object value);
        void SetFunction(string name, Delegate value);
        void Run(string script);
        object Evaluate(string script);
    }
};
