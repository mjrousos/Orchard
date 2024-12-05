using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Taxonomies.Models;

namespace Orchard.Taxonomies.ViewModels {
    public class ImportViewModel {
        public TaxonomyPart Taxonomy { get; set; }
        public string Terms { get; set; }
    }
}
