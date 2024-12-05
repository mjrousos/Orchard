using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Workflows.Models {
    public class CancellationToken {
        public void Cancel() {
            IsCancelled = true;
        }

        public bool IsCancelled { get; private set; }
    }
}
