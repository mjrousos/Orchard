using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;

namespace Orchard.AuditTrail.Models {
    public class AuditTrailPart : ContentPart {
        public string Comment {
            get { return RetrieveVersioned<string>("Comment"); }
            set { StoreVersioned("Comment", value); }
        }
        public bool ShowComment { get; set; }
    }
}
