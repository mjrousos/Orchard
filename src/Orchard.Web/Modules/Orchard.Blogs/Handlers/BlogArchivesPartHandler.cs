using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Blogs.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;

namespace Orchard.Blogs.Handlers {
    public class BlogArchivesPartHandler : ContentHandler {
        public BlogArchivesPartHandler(IRepository<BlogArchivesPartRecord> repository) {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}
