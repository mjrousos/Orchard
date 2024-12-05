using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Environment;

namespace Orchard.Tests.Environment {
    public class StubHostEnvironment : HostEnvironment {
        public override void RestartAppDomain() {
        }
    }
}
