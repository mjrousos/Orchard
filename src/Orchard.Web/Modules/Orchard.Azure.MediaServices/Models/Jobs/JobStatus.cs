using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Azure.MediaServices.Models.Jobs {
    public enum JobStatus {
        Pending,
        Processing,
        Finished,
        Canceling,
        Canceled,
        Queued,
		Scheduled,
		Faulted,
        Archived
    }
}
