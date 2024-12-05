using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using Orchard.ContentManagement.Records;

namespace Orchard.Core.Scheduling.Models {
    public class ScheduledTaskRecord {
        public virtual int Id { get; set; }
        public virtual string TaskType { get; set; }
        public virtual DateTime? ScheduledUtc { get; set; }
        public virtual ContentItemVersionRecord ContentItemVersionRecord { get; set; }
    }
}
