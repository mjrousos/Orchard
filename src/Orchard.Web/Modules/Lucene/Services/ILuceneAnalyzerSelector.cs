using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard;

namespace Lucene.Services {
    public interface ILuceneAnalyzerSelector : IDependency {
        LuceneAnalyzerSelectorResult GetLuceneAnalyzer(string indexName);
        string Name { get; }
    }
}
