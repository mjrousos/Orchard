using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;

namespace Markdown.Models {
    public class MarkdownSiteSettingsPart : ContentPart {
        public bool UseMarkdownForBlogs {
            get { return this.Retrieve(x => x.UseMarkdownForBlogs); }
            set { this.Store(x => x.UseMarkdownForBlogs, value); }
        }
    }
}
