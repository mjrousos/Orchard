using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Linq;
using System.Reflection;
using System.Web.Hosting;

namespace Orchard.Environment {
    public abstract class HostEnvironment : IHostEnvironment {
        public string MapPath(string virtualPath) {
            return HostingEnvironment.MapPath(virtualPath);
        }
        public bool IsAssemblyLoaded(string name) {
            return AppDomain.CurrentDomain.GetAssemblies().Any(assembly => new AssemblyName(assembly.FullName).Name == name);
        public abstract void RestartAppDomain();
    }
}
