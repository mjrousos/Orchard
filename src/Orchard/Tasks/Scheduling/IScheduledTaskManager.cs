using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using System.Collections.Generic;

namespace Orchard.Tasks.Scheduling {
    public interface IScheduledTaskManager : IDependency {
        void CreateTask(string taskType, DateTime scheduledUtc, ContentItem contentItem);
        
        IEnumerable<IScheduledTask> GetTasks(ContentItem contentItem);
        IEnumerable<IScheduledTask> GetTasks(string taskType, DateTime? scheduledBeforeUtc = null);
        void DeleteTasks(ContentItem contentItem, Func<IScheduledTask, bool> predicate = null);
    }
}
