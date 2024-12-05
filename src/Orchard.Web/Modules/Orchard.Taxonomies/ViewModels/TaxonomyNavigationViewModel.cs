using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.ComponentModel.DataAnnotations;

namespace Orchard.Taxonomies.ViewModels {
    public class TaxonomyNavigationViewModel {
        public SelectList AvailableTaxonomies { get; set; }
        [Required, Range(1, int.MaxValue, ErrorMessage = "You must select a taxonomy")]
        public int SelectedTaxonomyId { get; set; }
        public int SelectedTermId { get; set; }
        public bool DisplayTopMenuItem { get; set; }
        public bool DisplayContentCount { get; set; }
        public bool HideEmptyTerms { get; set; }
        public int LevelsToDisplay { get; set; }
    }
}
