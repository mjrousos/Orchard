using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.ContentManagement.Records;
using Orchard.Data.Conventions;

namespace Orchard.Taxonomies.Models {
    public class TermsPartRecord : ContentPartRecord {
        public TermsPartRecord() {
            Terms = new List<TermContentItem>();
        }
        [CascadeAllDeleteOrphan]
        public virtual IList<TermContentItem> Terms { get; set; }
    }
}
