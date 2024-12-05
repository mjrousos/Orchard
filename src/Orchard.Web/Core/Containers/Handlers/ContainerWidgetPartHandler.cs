using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement.Handlers;
using Orchard.Core.Containers.Models;
using Orchard.Data;

namespace Orchard.Core.Containers.Handlers {
    public class ContainerWidgetPartHandler : ContentHandler {
        public ContainerWidgetPartHandler(IRepository<ContainerWidgetPartRecord> repository) {
            Filters.Add(StorageFilter.For(repository));
            OnInitializing<ContainerWidgetPart>((context, part) => {
                part.Record.ContainerId = 0;
                part.Record.PageSize = 5;
            });
        }
    }
}
