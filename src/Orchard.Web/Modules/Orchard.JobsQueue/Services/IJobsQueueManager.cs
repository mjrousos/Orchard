using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.JobsQueue.Models;

namespace Orchard.JobsQueue.Services {
    public interface IJobsQueueManager : IDependency {
        QueuedJobRecord GetJob(int id);
        void Delete(QueuedJobRecord job);
        IEnumerable<QueuedJobRecord> GetJobs(int startIndex, int count);
        int GetJobsCount();
        void Resume();
        void Pause();
    }
}
