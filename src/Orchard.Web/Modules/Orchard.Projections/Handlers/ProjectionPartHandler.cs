using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Data;
using Orchard.ContentManagement.Handlers;
using Orchard.Projections.Models;

namespace Orchard.Projections.Handlers {
    public class ProjectionPartHandler : ContentHandler {
        public ProjectionPartHandler(IRepository<ProjectionPartRecord> projecRepository) {
            Filters.Add(StorageFilter.For(projecRepository));
        }
    }
}
