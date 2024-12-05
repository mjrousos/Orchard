using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;

namespace Orchard.JobsQueue.Models {
    public class JobsQueueSettingsPart : ContentPart {
        public JobsQueueStatus Status {
            get { return this.Retrieve(x => x.Status); }
            set { this.Store(x => x.Status, value); }
        }
    }
}
