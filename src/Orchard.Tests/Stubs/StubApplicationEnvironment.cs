using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Environment;

namespace Orchard.Tests.Stubs {
    public class StubApplicationEnvironment : IApplicationEnvironment {
        public StubApplicationEnvironment() {
            MachineName = "Orchard Machine";
        }
        public string MachineName { get; set; }
        public string GetEnvironmentIdentifier() {
            return MachineName;
    }
}
