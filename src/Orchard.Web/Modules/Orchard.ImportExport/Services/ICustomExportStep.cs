using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections.Generic;
using Orchard.Events;

namespace Orchard.ImportExport.Services {
    [Obsolete("Implement IRecipeBuilderStep instead.")]
    public interface ICustomExportStep : IEventHandler {
        void Register(IList<string> steps);
    }
}
