using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Caching;
using Orchard.FileSystems.VirtualPath;

namespace Orchard.Tests.Stubs {
    public class StubVirtualPathMonitor : IVirtualPathMonitor {
        public class Token : IVolatileToken {
            public bool IsCurrent { get; set; }
        }
        public IVolatileToken WhenPathChanges(string virtualPath) {
            return new Token();
    }
}
