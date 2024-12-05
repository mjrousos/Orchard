using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.ContentTypes.ViewModels {
    public class ListContentPartsViewModel {
        public IEnumerable<EditPartViewModel> Parts { get; set; }
    }
}
