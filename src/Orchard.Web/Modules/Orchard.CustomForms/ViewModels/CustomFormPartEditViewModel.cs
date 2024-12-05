using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.CustomForms.Models;

namespace Orchard.CustomForms.ViewModels {
    public class CustomFormPartEditViewModel {
        public IEnumerable<string> ContentTypes { get; set; }
        public CustomFormPart CustomFormPart { get; set; } 
    }
}
