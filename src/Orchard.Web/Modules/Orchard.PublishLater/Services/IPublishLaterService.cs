using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.PublishLater.Models;

namespace Orchard.PublishLater.Services {
    public interface IPublishLaterService : IDependency {
        DateTime? GetScheduledPublishUtc(PublishLaterPart publishLaterPart);
        void Publish(ContentItem contentItem, DateTime scheduledPublishUtc);
    }
}
