using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement.Handlers;
using Orchard.JobsQueue.Models;

namespace Orchard.JobsQueue.Handlers {
    public class JobsQueueSettingsPartHandler : ContentHandler {
        public JobsQueueSettingsPartHandler() {
            Filters.Add(new ActivatingFilter<JobsQueueSettingsPart>("Site"));
        }
    }
}
