using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.Rules.Models;

namespace Orchard.Rules.Handlers {
    public class ScheduledActionTaskPartHandler : ContentHandler {
        public ScheduledActionTaskPartHandler(IRepository<ScheduledActionTaskRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
            Filters.Add(new ActivatingFilter<ScheduledActionTaskPart>("ScheduledActionTask"));
        }
    }
}
