using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Lucene.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lucene.ViewModels {
    public class LuceneSettingsPartEditViewModel {
        public LuceneAnalyzerSelectorMapping[] LuceneAnalyzerSelectorMappings { get; set; }
        public IEnumerable<SelectListItem> LuceneAnalyzerSelectors { get; set; }
    }
}
