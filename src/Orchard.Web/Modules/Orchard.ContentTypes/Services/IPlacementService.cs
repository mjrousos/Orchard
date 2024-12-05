using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.ContentTypes.Settings;

namespace Orchard.ContentTypes.Services {
    public interface IPlacementService : IDependency {
        IEnumerable<DriverResultPlacement> GetDisplayPlacement(string contentType);
        IEnumerable<DriverResultPlacement> GetEditorPlacement(string contentType);
        IEnumerable<string> GetZones();
    }
}
