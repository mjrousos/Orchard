using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.Taxonomies.Models {
    public class TermPartNode {
        public TermPartNode() {
            Items = new List<TermPartNode>();
        }
        public List<TermPartNode> Items { get; set; }
        public TermPartNode Parent { get; set; }
        public TermPart TermPart { get; set; }
        public int Level { get; set; }
        public dynamic Shape { get; set; }
    }
}
