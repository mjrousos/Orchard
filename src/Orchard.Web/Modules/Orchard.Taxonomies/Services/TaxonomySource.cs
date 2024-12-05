using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;
using Orchard.Taxonomies.Models;

namespace Orchard.Taxonomies.Services {
    public class TaxonomySource : ITaxonomySource {
        private readonly ITaxonomyService _taxonomyService;
        public TaxonomySource(ITaxonomyService taxonomyService) {
            _taxonomyService = taxonomyService;
        }
        public TaxonomyPart GetTaxonomy(string name, ContentItem item) {
            return _taxonomyService.GetTaxonomyByName(name);
    }
}
