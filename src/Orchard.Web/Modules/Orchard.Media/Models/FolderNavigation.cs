using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Media.Models {
    public class FolderNavigation {
        public string FolderName { get; set; }
        public string FolderPath { get; set; }
    }
}
