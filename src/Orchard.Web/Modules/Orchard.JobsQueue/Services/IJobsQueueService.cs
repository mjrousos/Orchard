using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Events;
using Orchard.JobsQueue.Models;

namespace Orchard.JobsQueue.Services {
    public interface IJobsQueueService : IEventHandler {
        QueuedJobRecord Enqueue(string message, object parameters, int priority);
    }
}
