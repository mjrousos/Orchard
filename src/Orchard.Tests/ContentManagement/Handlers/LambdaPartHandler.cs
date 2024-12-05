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
using Orchard.Tests.ContentManagement.Models;
using Orchard.Tests.ContentManagement.Records;

namespace Orchard.Tests.ContentManagement.Handlers {
    public class LambdaPartHandler : ContentHandler {
        public LambdaPartHandler(IRepository<LambdaRecord> repository) {
            Filters.Add(new ActivatingFilter<LambdaPart>("lambda"));
            Filters.Add(StorageFilter.For(repository));
        }
    }
}
