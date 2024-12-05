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
using Orchard.Core.Common.ViewModels;

namespace Orchard.ArchiveLater.ViewModels {
    public class ArchiveLaterViewModel {
        private readonly ArchiveLaterPart _archiveLaterPart;
        public ArchiveLaterViewModel(ArchiveLaterPart archiveLaterPart) {
            _archiveLaterPart = archiveLaterPart;
        }
        public bool ArchiveLater { get; set; }
        public ContentItem ContentItem { get { return _archiveLaterPart.ContentItem; } }
        public bool IsPublished {
            get { return ContentItem.VersionRecord != null && ContentItem.VersionRecord.Published; }
        public DateTimeEditor Editor { get; set; }
    }
}
