using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Data.Providers {
    public class DataServiceParameters {
        public string Provider { get; set; }
        public string DataFolder { get; set; }
        public string ConnectionString { get; set; }
    }
}
