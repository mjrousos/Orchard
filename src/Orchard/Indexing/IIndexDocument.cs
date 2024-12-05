using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.Indexing {
    public interface IDocumentIndex {
        IDocumentIndex SetContentItemId(int contentItemId);
        IDocumentIndex Add(string name, string value);
        IDocumentIndex Add(string name, DateTime value);
        IDocumentIndex Add(string name, int value);
        IDocumentIndex Add(string name, bool value);
        IDocumentIndex Add(string name, double value);
        /// <summary>
        /// Stores the original value to the index.
        /// </summary>
        IDocumentIndex Store();
        /// Content is analyzed and tokenized.
        IDocumentIndex Analyze();
        /// Remove any HTML tag from the current string
        IDocumentIndex RemoveTags();
        /// Whether some property have been added to this document, or otherwise if it's empty
        bool IsDirty { get; }
    }
}
