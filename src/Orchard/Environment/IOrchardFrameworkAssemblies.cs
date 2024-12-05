using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.Reflection;

namespace Orchard.Environment {
    public interface IOrchardFrameworkAssemblies : IDependency {
        IEnumerable<AssemblyName> GetFrameworkAssemblies();
    }
    public class DefaultOrchardFrameworkAssemblies : IOrchardFrameworkAssemblies {
        public IEnumerable<AssemblyName> GetFrameworkAssemblies() {
            return typeof (IDependency).Assembly.GetReferencedAssemblies();
        }
}
