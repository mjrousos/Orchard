using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.ComponentModel.DataAnnotations;

namespace Orchard.Blogs.Models {
    public class RecentBlogPostsPart : ContentPart<RecentBlogPostsPartRecord> {
        public int BlogId {
            get { return Record.BlogId; }
            set { Record.BlogId = value; }
        }
        [Required]
        public int Count {
            get { return Record.Count; }
            set { Record.Count = value; }
    }
}
