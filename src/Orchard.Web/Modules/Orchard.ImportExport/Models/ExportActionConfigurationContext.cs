using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Xml.Linq;
using Orchard.Recipes.Models;

namespace Orchard.ImportExport.Models {
    public class ExportActionConfigurationContext : ConfigurationContext {
        public ExportActionConfigurationContext(XElement configurationElement) : base(configurationElement) {
        }
    }
}
