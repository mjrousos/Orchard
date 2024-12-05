using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Taxonomies.Models;

namespace Orchard.Taxonomies.Settings {
    public class TaxonomyFieldSettings {
        /// <summary>
        /// Wether the field allows the user to add new Terms to the taxonomy (similar to tags)
        /// </summary>
        public bool AllowCustomTerms { get; set; }
        /// The Taxonomy to which this field is related to
        public string Taxonomy { get; set; }
        /// Wether the user can only select leaves in the taxonomy
        public bool LeavesOnly { get; set; }
        /// Wether the user can select only one term or not
        public bool SingleChoice { get; set; }
        /// Wether the user will be presented with an autocomplete text field to apply terms to the content item
        public bool Autocomplete { get; set; }
        /// A help text to display in the editor
        public string Hint { get; set; }
        /// All existing taxonomies
        public IEnumerable<TaxonomyPart> Taxonomies { get; set; }
        public bool Required { get; set; }
    }
}
