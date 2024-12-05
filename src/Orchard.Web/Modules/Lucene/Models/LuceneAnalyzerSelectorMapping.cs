using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Lucene.Models {
    public class LuceneAnalyzerSelectorMapping {
        public string IndexName { get; set; }
        public string AnalyzerName { get; set; }
    }
}
