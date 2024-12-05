using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Tasks;

namespace Orchard.JobsQueue.Services {
    public class JobsQueueBackgroundTask : Component, IBackgroundTask {
        private readonly IJobsQueueProcessor _jobsQueueProcessor;
        public JobsQueueBackgroundTask(IJobsQueueProcessor jobsQueueProcessor) {
            _jobsQueueProcessor = jobsQueueProcessor;
        }
        public void Sweep() {
            _jobsQueueProcessor.ProcessQueue(1, uint.MaxValue);
    }
}
