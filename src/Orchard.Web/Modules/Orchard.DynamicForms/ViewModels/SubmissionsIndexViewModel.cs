using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Data;

namespace Orchard.DynamicForms.ViewModels {
    public class SubmissionsIndexViewModel {
        public string FormName { get; set; }
        public DataTable Submissions { get; set; }
        public dynamic Pager { get; set; }
    }
}
