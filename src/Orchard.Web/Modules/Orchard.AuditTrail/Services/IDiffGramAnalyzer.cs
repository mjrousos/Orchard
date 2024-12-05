using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.Xml.Linq;
using Orchard.AuditTrail.Services.Models;

namespace Orchard.AuditTrail.Services {
    public interface IDiffGramAnalyzer : IDependency {
        /// <summary>
        /// Compares the specified XML elements and returns a DiffGram XML element.
        /// </summary>
        XElement GenerateDiffGram(XElement element1, XElement element2);
        /// Analyzes the specified DiffGram element against the specified original XML element and returns a list of diff nodes,
        /// where each node describes a difference between the original and updated document.
        IEnumerable<DiffNode> Analyze(XElement original, XElement diffGram);
    }
}
