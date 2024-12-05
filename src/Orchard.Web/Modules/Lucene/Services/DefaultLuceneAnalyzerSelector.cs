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
using Lucene.Net.Analysis.Standard;

namespace Lucene.Services {
    public class DefaultLuceneAnalyzerSelector : ILuceneAnalyzerSelector {
        public LuceneAnalyzerSelectorResult GetLuceneAnalyzer(string indexName) {
            return new LuceneAnalyzerSelectorResult {
                Priority = -5,
                Analyzer = new StandardAnalyzer(LuceneIndexProvider.LuceneVersion)
            };
        }
        public string Name { get { return "Default"; } }
    }
}
