using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Diagnostics;

namespace Orchard.Environment {
    public class ApplicationEnvironment : IApplicationEnvironment {
        public string GetEnvironmentIdentifier() {
            // Add process ID to machine name because multiple web servers can
            // be running on the same physical machine.
            return String.Format("{0}:{1}", System.Environment.MachineName, Process.GetCurrentProcess().Id);
        }
    }
}
