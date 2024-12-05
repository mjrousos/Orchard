using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.Events;
using Orchard.ImportExport.Models;

namespace Orchard.ImportExport.Services {
    [Obsolete("Implement IRecipeExecutionStep instead.")]
    public interface IExportEventHandler : IEventHandler {
        void Exporting(ExportContext context);
        void Exported(ExportContext context);
    }
}
