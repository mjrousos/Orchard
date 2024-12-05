using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Orchard.ContentManagement.FieldStorage.InfosetStorage;

namespace Orchard.Taxonomies.Models {
    public class TaxonomyNavigationPart : ContentPart {
        /// <summary>
        /// The taxonomy to display
        /// </summary>
        public int TaxonomyId {
            get { return Convert.ToInt32(this.As<InfosetPart>().Get("TaxonomyNavigationPart", "TaxonomyId", null), CultureInfo.InvariantCulture); }
            set { this.As<InfosetPart>().Set("TaxonomyNavigationPart", "TaxonomyId", null, Convert.ToString(value, CultureInfo.InvariantCulture)); }
        }
        /// Top term to display in the menu.
        /// If null, the taxonomy is supposed to be the top term.
        public int TermId {
            get { return Convert.ToInt32(this.As<InfosetPart>().Get("TaxonomyNavigationPart", "TermId", null), CultureInfo.InvariantCulture); }
            set { this.As<InfosetPart>().Set("TaxonomyNavigationPart", "TermId", null, Convert.ToString(value, CultureInfo.InvariantCulture)); }
        /// Whether to display the root node or not.
        /// If <c>False</c>, the menu will have a flat first level.
        public bool DisplayRootTerm {
            get { return Convert.ToBoolean(this.As<InfosetPart>().Get("TaxonomyNavigationPart", "DisplayRootTerm", null), CultureInfo.InvariantCulture); }
            set { this.As<InfosetPart>().Set("TaxonomyNavigationPart", "DisplayRootTerm", null, Convert.ToString(value, CultureInfo.InvariantCulture)); }
        /// Number of levels to render. If <value>0</value> all levels are rendered.
        public int LevelsToDisplay {
            get { return Convert.ToInt32(this.As<InfosetPart>().Get("TaxonomyNavigationPart", "LevelsToDisplay"), CultureInfo.InvariantCulture); }
            set { this.As<InfosetPart>().Set("TaxonomyNavigationPart", "LevelsToDisplay", Convert.ToString(value, CultureInfo.InvariantCulture)); }
        /// Whether to display the number of content items
        /// associated with this term, in the generated menu item text
        public bool DisplayContentCount {
            get { return Convert.ToBoolean(this.As<InfosetPart>().Get("TaxonomyNavigationPart", "DisplayContentCount", null), CultureInfo.InvariantCulture); }
            set { this.As<InfosetPart>().Set("TaxonomyNavigationPart", "DisplayContentCount", null, Convert.ToString(value, CultureInfo.InvariantCulture)); }
        /// Whether to hide the terms without any associated content
        public bool HideEmptyTerms {
            get { return Convert.ToBoolean(this.As<InfosetPart>().Get("TaxonomyNavigationPart", "HideEmptyTerms", null), CultureInfo.InvariantCulture); }
            set { this.As<InfosetPart>().Set("TaxonomyNavigationPart", "HideEmptyTerms", null, Convert.ToString(value, CultureInfo.InvariantCulture)); }
    }
}
