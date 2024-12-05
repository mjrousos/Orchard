using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.ImportExport.ViewModels {
    public class ImportViewModel {
        public ImportViewModel() {
            Actions = new List<ImportActionViewModel>();
        }
        public IList<ImportActionViewModel> Actions { get; set; }
    }
}
