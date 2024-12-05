using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Tags.ViewModels {
    public class TagsSearchViewModel {
        public string TagName { get; set; }
        public dynamic List { get; set; }
        public dynamic Pager { get; set; }
    }
}
