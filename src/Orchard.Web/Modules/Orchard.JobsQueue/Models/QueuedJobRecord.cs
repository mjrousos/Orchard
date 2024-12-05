using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using Orchard.Data.Conventions;

namespace Orchard.JobsQueue.Models {
    public class QueuedJobRecord {
        public virtual int Id { get; set; }
        public virtual int Priority { get; set; }
        public virtual string Message { get; set; }
        
        [StringLengthMax]
        public virtual string Parameters { get; set; }
        public virtual DateTime CreatedUtc { get; set; }
    }
}
