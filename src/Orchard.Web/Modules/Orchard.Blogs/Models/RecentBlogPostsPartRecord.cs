using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement.Records;

namespace Orchard.Blogs.Models {
    public class RecentBlogPostsPartRecord : ContentPartRecord {
        public RecentBlogPostsPartRecord() {
            Count = 5;
        }
        public virtual int BlogId { get; set; }
        public virtual int Count { get; set; }
    }
}
