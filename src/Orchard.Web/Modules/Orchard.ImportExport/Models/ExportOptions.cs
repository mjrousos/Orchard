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

namespace Orchard.ImportExport.Models {
    [Obsolete]
    public class ExportOptions {
        public IEnumerable<string> CustomSteps { get; set; }
    }
}
