using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Environment.Extensions.Models;

namespace Orchard.Environment.Extensions.Folders {
    public interface IExtensionFolders {
        IEnumerable<ExtensionDescriptor> AvailableExtensions();
    }
}
