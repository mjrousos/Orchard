using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Environment.Extensions;

namespace Orchard.Search {
    [OrchardFeature("Orchard.Search.Blogs")]
    public class BlogSearchConstants {
        public static string ADMIN_BLOGPOSTS_INDEX = "AdminBlogPosts";
    }
}
