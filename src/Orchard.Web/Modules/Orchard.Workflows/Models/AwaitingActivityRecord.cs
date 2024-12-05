using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Workflows.Models {
    public class AwaitingActivityRecord {
        public virtual int Id { get; set; }

        public virtual ActivityRecord ActivityRecord { get; set; }
        // Parent property
        public virtual WorkflowRecord WorkflowRecord { get; set; }
    }
}
