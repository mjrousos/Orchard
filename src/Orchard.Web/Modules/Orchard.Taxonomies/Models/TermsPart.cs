using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.ContentManagement.Utilities;

namespace Orchard.Taxonomies.Models {
    /// <summary>
    /// This Content Part is used to create a link to TermContentItem records, so
    /// that the Content Manager can query them. It will be attached dynamically whenever
    /// a TaxonomyField is found on a Content Type
    /// </summary>
    public class TermsPart : ContentPart<TermsPartRecord> {
        public IList<TermContentItem> Terms { get { return Record.Terms; } }
        internal LazyField<IEnumerable<TermContentItemPart>> _termParts;
        public IEnumerable<TermContentItemPart> TermParts {
            get { return _termParts.Value; }
            set { _termParts.Value = value; }
        }
    }
}
