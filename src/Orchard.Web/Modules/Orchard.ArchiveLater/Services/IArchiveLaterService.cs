using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.ArchiveLater.Models;

namespace Orchard.ArchiveLater.Services {
    public interface IArchiveLaterService : IDependency {
        DateTime? GetScheduledArchiveUtc(ArchiveLaterPart archiveLaterPart);
        void ArchiveLater(ContentItem contentItem, DateTime scheduledArchiveUtc);
        void RemoveArchiveLaterTasks(ContentItem contentItem);
    }
}
