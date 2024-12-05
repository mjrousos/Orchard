using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.ContentManagement.Utilities;

namespace Orchard.ArchiveLater.Models {
    public class ArchiveLaterPart : ContentPart {
        private readonly LazyField<DateTime?> _scheduledArchiveUtc = new LazyField<DateTime?>();
        public LazyField<DateTime?> ScheduledArchiveUtc { get { return _scheduledArchiveUtc; } }
    }
}
