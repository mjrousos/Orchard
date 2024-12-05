using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web.Hosting;

namespace Orchard.FileSystems.VirtualPath {
    public interface ICustomVirtualPathProvider {
        VirtualPathProvider Instance { get; }
    }
}
