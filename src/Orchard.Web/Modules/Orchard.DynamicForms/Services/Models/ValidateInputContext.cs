using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Specialized;

namespace Orchard.DynamicForms.Services.Models {
    public class ValidateInputContext : ValidationContext {
        public ModelStateDictionary ModelState { get; set; }
        public string AttemptedValue { get; set; }
        public NameValueCollection Values { get; set; }
        public IUpdateModel Updater { get; set; }
    }
}
