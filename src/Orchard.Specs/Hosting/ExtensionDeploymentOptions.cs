using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.Specs.Hosting {
    [Flags]
    public enum ExtensionDeploymentOptions {
        CompiledAssembly = 0x01,
        SourceCode = 0x02,
    }
    public enum DynamicCompilationOption {
        Enabled,        // Allow compiling of csproj files as needed
        Disabled,       // Never compile csproj files
        Force           // Force loading modules by compiling csproj files
}
