using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Xml.Linq;

namespace Orchard.ImportExport.Models {
    public class ExportContext {
        public XDocument Document { get; set; }
        [Obsolete]
        public ExportOptions ExportOptions { get; set; }
    }
}
