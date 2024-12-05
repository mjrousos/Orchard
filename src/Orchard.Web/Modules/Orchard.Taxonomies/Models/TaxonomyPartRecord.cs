using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement.Records;

namespace Orchard.Taxonomies.Models {
    public class TaxonomyPartRecord : ContentPartRecord {
        public virtual string TermTypeName { get; set; }
        public virtual bool IsInternal { get; set; }
    }
}
