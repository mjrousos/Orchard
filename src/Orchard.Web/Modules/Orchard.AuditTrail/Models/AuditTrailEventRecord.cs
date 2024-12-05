using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.Data.Conventions;

namespace Orchard.AuditTrail.Models {
    /// <summary>
    /// Audit Trail Event Record in the database.
    /// </summary>
    public class AuditTrailEventRecord {
        public virtual int Id { get; set; }
        /// <summary>
        /// The time when the event occurred.
        /// </summary>
        public virtual DateTime CreatedUtc { get; set; }
        /// The user name of the user who caused the event to occur.
        public virtual string UserName { get; set; }
        /// The name of the event.
        public virtual string EventName { get; set; }
        /// The full name of the event.
        public virtual string FullEventName { get; set; }
        /// The category the event belongs to.
        public virtual string Category { get; set; }
        /// The data of the event.
        [StringLengthMax]
        public virtual string EventData { get; set; }
        /// The filter key of the event.
        public virtual string EventFilterKey { get; set; }
        /// The filter data of the event.
        public virtual string EventFilterData { get; set; }
        /// The comment of the event.
        public virtual string Comment { get; set; }
        /// The IP address of the user who caused the event to occur.
        public virtual string ClientIpAddress { get; set; }
    }
}
