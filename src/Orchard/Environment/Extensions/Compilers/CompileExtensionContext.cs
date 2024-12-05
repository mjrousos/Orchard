using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Environment.Extensions.Compilers {
    public class CompileExtensionContext {
        public string VirtualPath { get; set; }
        public IAssemblyBuilder AssemblyBuilder { get; set; }
    }
}
