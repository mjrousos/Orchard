using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.Rules.Models {
    public class ScheduledActionTaskPart : ContentPart<ScheduledActionTaskRecord> {
        public virtual IList<ScheduledActionRecord> ScheduledActions {
            get { return Record.ScheduledActions; }
        }
    }
}
