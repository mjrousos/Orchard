using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement.Handlers;
using Orchard.Core.Common.Models;
using Orchard.Core.Title.Models;

namespace Orchard.Tests.ContentManagement.Handlers {
    public class DummyHandler : ContentHandler {
        public DummyHandler() {
            Filters.Add(new ActivatingFilter<IdentityPart>("Dummy"));
            Filters.Add(new ActivatingFilter<TitlePart>("Dummy"));
        }
    }
}
