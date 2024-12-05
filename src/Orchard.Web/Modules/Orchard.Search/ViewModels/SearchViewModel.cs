using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Search.ViewModels {
    public class SearchViewModel {
        public string Query { get; set; }
        public int TotalItemCount { get; set; }
        public int StartPosition { get; set; }
        public int EndPosition { get; set; }
        public dynamic ContentItems { get; set; }
        public dynamic Pager { get; set; }
        public string IndexName { get; set; }
    }
}
