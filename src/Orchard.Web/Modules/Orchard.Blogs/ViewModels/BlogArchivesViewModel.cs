using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Blogs.Models;

namespace Orchard.Blogs.ViewModels {
    public class BlogArchivesViewModel {
        public int BlogId { get; set; }
        public IEnumerable<BlogPart> Blogs { get; set; }
    }
}
