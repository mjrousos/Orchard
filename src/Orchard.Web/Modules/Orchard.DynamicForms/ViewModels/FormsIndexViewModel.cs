using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.Linq;
using Orchard.DynamicForms.Models;

namespace Orchard.DynamicForms.ViewModels {
    public class FormsIndexViewModel {
        public IList<IGrouping<string, Submission>> Forms { get; set; }
    }
}
