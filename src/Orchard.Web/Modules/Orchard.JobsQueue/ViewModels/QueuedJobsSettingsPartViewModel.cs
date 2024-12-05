using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.JobsQueue.Models;

namespace Orchard.JobsQueue.ViewModels {
    public class JobsQueueSettingsPartViewModel {
        public JobsQueueSettingsPart JobsQueueSettings { get; set; }
    }
}
