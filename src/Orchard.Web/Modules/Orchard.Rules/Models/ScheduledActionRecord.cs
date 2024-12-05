using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Data.Conventions;

namespace Orchard.Rules.Models {
    public class ScheduledActionRecord {
        public virtual int Id { get; set; }
        [CascadeAllDeleteOrphan]
        public virtual ActionRecord ActionRecord { get; set; }
    }
}
