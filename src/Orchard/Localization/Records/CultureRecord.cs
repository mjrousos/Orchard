using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Localization.Records {
        public class CultureRecord {
            public virtual int Id { get; set; }
            public virtual string Culture { get; set; }
        }
}
