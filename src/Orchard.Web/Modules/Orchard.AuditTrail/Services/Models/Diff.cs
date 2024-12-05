using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.AuditTrail.Services.Models {
    public class Diff<T> {
        public T OldValue { get; set; }
        public T NewValue { get; set; }
    }
}
