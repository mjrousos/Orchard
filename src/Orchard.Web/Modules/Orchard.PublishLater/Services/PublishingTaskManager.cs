using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using System.Linq;
using Orchard.Tasks.Scheduling;

namespace Orchard.PublishLater.Services {
    public class PublishingTaskManager : IPublishingTaskManager {
        private const string PublishTaskType = "Publish";
        private readonly IScheduledTaskManager _scheduledTaskManager;
        public PublishingTaskManager(IScheduledTaskManager scheduledTaskManager) {
            _scheduledTaskManager = scheduledTaskManager;
        }
        public IScheduledTask GetPublishTask(ContentItem item) {
            return _scheduledTaskManager
                .GetTasks(item)
                .Where(task => task.TaskType == PublishTaskType)
                .SingleOrDefault();
        public void Publish(ContentItem item, DateTime scheduledUtc) {
            DeleteTasks(item);
            _scheduledTaskManager.CreateTask(PublishTaskType, scheduledUtc, item);
        public void DeleteTasks(ContentItem item) {
            _scheduledTaskManager.DeleteTasks(item, task => task.TaskType == PublishTaskType);
    }
}
