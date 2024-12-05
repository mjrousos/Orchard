using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Packaging.Models {
    public class PackagingSource {
        public virtual int Id { get; set; }
        public virtual string FeedTitle { get; set; }
        public virtual string FeedUrl { get; set; }
    }
}
