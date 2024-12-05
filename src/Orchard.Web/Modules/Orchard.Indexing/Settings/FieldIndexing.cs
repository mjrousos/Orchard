using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Indexing.Settings {
    public class FieldIndexing {
        public FieldIndexing() {
            Analyzed = true;
            TagsRemoved = true;
        }

        public bool Included { get; set; }
        public bool Stored { get; set; }
        public bool Analyzed { get; set; }
        public bool TagsRemoved { get; set; }
    }
}
