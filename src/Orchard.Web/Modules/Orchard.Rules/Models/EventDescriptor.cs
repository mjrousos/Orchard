using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.Rules.Models {
    public class EventDescriptor {
        public string Category { get; set; } // e.g. Content
        public string Type { get; set; } // e.g. Created
        public LocalizedString Name { get; set; }
        public LocalizedString Description { get; set; }
        public Func<EventContext, bool> Condition { get; set; }
        public string Form { get; set; }
        public Func<EventContext, LocalizedString> Display { get; set; }
    }
}
