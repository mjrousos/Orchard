using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.ContentManagement.Records;
using Orchard.Data.Conventions;

namespace Orchard.Rules.Models {
    public class ScheduledActionTaskRecord : ContentPartVersionRecord {
        public ScheduledActionTaskRecord() {
            ScheduledActions = new List<ScheduledActionRecord>();
        }
        [CascadeAllDeleteOrphan]
        public virtual IList<ScheduledActionRecord> ScheduledActions { get; set; }
    }
}
