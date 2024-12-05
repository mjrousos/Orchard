using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Taxonomies.Fields;
using Orchard.Taxonomies.Models;

namespace Orchard.Taxonomies.Services {
    public interface ITaxonomySource : IDependency {
        TaxonomyPart GetTaxonomy(string name, ContentItem item);
    }
}
