using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Core.Common.ViewModels;

namespace Orchard.AuditTrail.ViewModels {
    public class CommonAuditTrailFilterViewModel {
        public CommonAuditTrailFilterViewModel() {
            From = new DateTimeEditor { ShowDate = true, ShowTime = false};
            To = new DateTimeEditor { ShowDate = true, ShowTime = false };
        }
        public string UserName { get; set; }
        public DateTimeEditor From { get; set; }
        public DateTimeEditor To { get; set; }
    }
}
