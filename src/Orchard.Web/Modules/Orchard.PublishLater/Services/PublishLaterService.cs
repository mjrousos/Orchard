using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.Core.Contents;
using Orchard.PublishLater.Models;
using Orchard.Tasks.Scheduling;

namespace Orchard.PublishLater.Services {
    public class PublishLaterService : IPublishLaterService {
        private readonly IPublishingTaskManager _publishingTaskManager;
        public PublishLaterService(
            IOrchardServices services,  
            IPublishingTaskManager publishingTaskManager) {
            Services = services;
            _publishingTaskManager = publishingTaskManager;
            T = NullLocalizer.Instance;
        }
        public IOrchardServices Services { get; set; }
        public Localizer T { get; set; }
        void IPublishLaterService.Publish(ContentItem contentItem, DateTime scheduledPublishUtc) {
            if (!Services.Authorizer.Authorize(Permissions.PublishContent, contentItem, T("Couldn't publish selected content.")))
                return;
            _publishingTaskManager.Publish(contentItem, scheduledPublishUtc);
        DateTime? IPublishLaterService.GetScheduledPublishUtc(PublishLaterPart publishLaterPart) {
            IScheduledTask task = _publishingTaskManager.GetPublishTask(publishLaterPart.ContentItem);
            return (task == null ? null : task.ScheduledUtc);
    }
}
